using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Pico;
using Unity.XR.PXR;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using Tobii.XR.Examples.GettingStarted;
using Tobii.G2OM;

public class ET_Objects : ETObject , IGazeFocusable
{
    public Color HighLightColor;

    public Color originColor;
    bool triggerValue;

    public Transform spot;
    private Renderer targetRenderer;
    bool focusing;
    Vector3 newPosition;
    Vector3 originalPos;

    private Matrix4x4 headPoseMatrix;

    public Transform parentObject; // Drag and drop the parent GameObject here in the Inspector
    public GameObject childObject;
    private float previousLEyeOpenness = 1.0f;
    private float previousREyeOpenness = 1.0f;
    private int blinkCount = 0;
    private Vector3 previousPosition;
    public bool userFocusing = false;
    private bool positionSetThisBlink = false;

    public Light spotlight;
    public GameObject spotlightCylinder;
  //  private Matrix4x4 headPoseMatrix;
    bool SelectObject = false;

    public float topBoundary = 5f;
    public float bottomBoundary = -5f;
    public float leftBoundary = -5f;
    public float rightBoundary = 5f;


    public Camera xrCamera;

    private void Start()
    {
        if (gameObject.TryGetComponent<Renderer>(out targetRenderer))
        {
            originColor = targetRenderer.material.color;
        }
        originalPos = transform.position;


    }


    private void Update()
    {
        PXR_EyeTracking.GetHeadPosMatrix(out headPoseMatrix);
      

     

        //  CheckHeadsetOrientation_(headPoseMatrix);

        float currentLEyeOpenness = 0;
        float currentREyeOpenness = 0;

        PXR_MotionTracking.GetEyeOpenness(ref currentLEyeOpenness, ref currentREyeOpenness);
        /*
        if (parentObject.childCount > 0)
        {
         //   Transform existingChild = parentObject.GetChild(0);
           // existingChild.SetParent(null);

        }

        */

      //  CheckIFSpotLineShining();
    //    CheckifShining();

        // Update the previous position for the next frame
        previousPosition = transform.position;

        if ( userFocusing)
        {
            GetComponent<Renderer>().material.color = HighLightColor;
            LeftEyeBlink(currentLEyeOpenness);
         
        } else if(!userFocusing || ( childObject.transform.parent != parentObject.transform))
        {
            
            GetComponent<Renderer>().material.color = originColor;
        }

        if(childObject.transform.parent != parentObject.transform)
        {
           // Debug.Log("turnBack to original color");
        }
       

          
      

        RightEyeBlink(currentREyeOpenness);

        previousLEyeOpenness = currentLEyeOpenness;
        previousREyeOpenness = currentREyeOpenness;
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if(hasFocus)
        {
         //   GetComponent<Renderer>().material.color = HighLightColor;
           
          //  userFocusing = true;
            Debug.Log("looking at the object" + userFocusing);
        } else
        {
            Debug.Log("Not looking " + userFocusing);
         //   userFocusing = false;
         //   GetComponent<Renderer>().material.color = originColor;

        }
    }

    private void LeftEyeBlink(float currentLEyeOpenness)
    {
        if (parentObject.childCount == 1)
        {
            if (previousLEyeOpenness == 1.0f && currentLEyeOpenness < 1.0f)
            {
                SelectObject = true;

                /*
                if (!positionSetThisBlink)
                {
                    parentObject.transform.LookAt(childObject.transform);

                    positionSetThisBlink = true;
                }
                */

                if (transform.position != previousPosition)
                {
                    // The object is moving
                   parentObject.transform.LookAt(childObject.transform);
                    Debug.Log("Object is moving");
                }
             //  parentObject.transform.LookAt(childObject.transform);


                Vector3 clampedPosition = transform.localPosition;
                clampedPosition.x = Mathf.Clamp(transform.localPosition.x, leftBoundary, rightBoundary);
                clampedPosition.y = Mathf.Clamp(transform.localPosition.y, bottomBoundary, topBoundary);
                //  transform.localPosition = clampedPosition;

                childObject.transform.SetParent(parentObject);
                //childObject.transform.localRotation = Quaternion.identity;

                blinkCount++;


            }
        }
    }
    private void RightEyeBlink(float currentREyeOpenness)
    {
        if (previousREyeOpenness == 1.0f && currentREyeOpenness < 1.0f)
        {
            childObject.transform.SetParent(null);
            positionSetThisBlink = false;

            blinkCount++;
            userFocusing = false;
           
        }
    }
 


    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == spotlightCylinder)
        {
            userFocusing = true;
            Debug.Log("on enter trigger "+ spotlightCylinder + " " + userFocusing);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == spotlightCylinder)
        {
           userFocusing = false;
            Debug.Log("on exit trigger " + spotlightCylinder);
        }
    }
    public void Move_ZAxis()
    {
        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            //    transform.Translate(Vector3.up * 0.35f * Time.deltaTime);

            //  transform.Translate(Vector3.forward * 0.15f * Time.deltaTime);
            transform.Translate(0.5f * Time.deltaTime * transform.forward);
            //  parentObject.transform.LookAt(childObject.transform);
        }

        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.secondaryButton, out triggerValue) && triggerValue)
        {
            transform.Translate(-0.5f * Time.deltaTime * transform.forward);
            // transform.Translate(Vector3.forward * -0.15f * Time.deltaTime);
            //  parentObject.transform.LookAt(childObject.transform);
            //   transform.Translate(Vector3.down * 0.35f * Time.deltaTime);
        }
    }
    public override void IsFocused()
    {
        base.IsFocused();
        isFocused = true;
       
    }

    public override void UnFocused()
    {
        base.UnFocused();
        isFocused = false;
     
    }

}
