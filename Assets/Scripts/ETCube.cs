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

public class ETCube : ETObject , IGazeFocusable
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

    bool userFocusing;
    private bool positionSetThisBlink = false;
  //  private Matrix4x4 headPoseMatrix;
    bool SelectObject = false;

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
        /*
        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            childObject.transform.SetParent(parentObject);
            childObject.transform.localPosition = Vector3.zero;
            //  transform.position = Vector3.Lerp(transform.position, parentObject.position, 5 * Time.deltaTime);
            //   Vector3 targetPosition = new Vector3(parentObject.position.x, transform.position.y, transform.position.z);

            // Use Vector3.Lerp to smoothly interpolate between current position and target position
            //      transform.position = Vector3.Lerp(transform.position, targetPosition, 5 * Time.deltaTime);
            // Smoothly rotate the rotation
            //  transform.rotation = Quaternion.Lerp(transform.rotation, parentObject.rotation, 5 * Time.deltaTime);

           
        }
     else childObject.transform.SetParent(null);
        //  else transform.position = originalPos;

        /* newPosition = new Vector3(spot.position.x, spot.position.y, transform.position.z);
           transform.position = newPosition;*/

        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            //    transform.Translate(Vector3.up * 0.35f * Time.deltaTime);
       
          //  transform.Translate(Vector3.forward * 0.15f * Time.deltaTime);
            transform.Translate(0.15f * Time.deltaTime * transform.forward);
            //  parentObject.transform.LookAt(childObject.transform);
        }

        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.secondaryButton, out triggerValue) && triggerValue)
        {
            transform.Translate(-0.15f * Time.deltaTime * transform.forward);
           // transform.Translate(Vector3.forward * -0.15f * Time.deltaTime);
          //  parentObject.transform.LookAt(childObject.transform);
            //   transform.Translate(Vector3.down * 0.35f * Time.deltaTime);
        }






        //  CheckHeadsetOrientation_(headPoseMatrix);

        float currentLEyeOpenness = 0;
        float currentREyeOpenness = 0;

        PXR_MotionTracking.GetEyeOpenness(ref currentLEyeOpenness, ref currentREyeOpenness);


        if(userFocusing)
        {
            if (parentObject.childCount > 0)
            {
                Transform existingChild = parentObject.GetChild(0);
                  existingChild.SetParent(null);
              
            }
            LeftEyeBlink(currentLEyeOpenness);
        } else
        {
            RightEyeBlink(currentREyeOpenness);
        }

        previousLEyeOpenness = currentLEyeOpenness;
        previousREyeOpenness = currentREyeOpenness;
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if(hasFocus)
        {
            GetComponent<Renderer>().material.color = HighLightColor;
          
            userFocusing = true;
            Debug.Log("looking");
        } else
        {
         
            userFocusing = false;
            GetComponent<Renderer>().material.color = originColor;

        }
    }

    private void LeftEyeBlink(float currentLEyeOpenness)
    {
        if (previousLEyeOpenness == 1.0f && currentLEyeOpenness < 1.0f)
        {
            SelectObject = true;

            if (!positionSetThisBlink)
            {
                parentObject.transform.LookAt(childObject.transform);
                positionSetThisBlink = true;
            }
            /*
            if (parentObject.childCount > 0)
            {
                //Transform existingChild = parentObject.GetChild(0);
              //  existingChild.SetParent(null);
            }
            */

            childObject.transform.SetParent(parentObject);

            childObject.transform.localRotation = Quaternion.identity;

            blinkCount++;
        }
    }
    private void RightEyeBlink(float currentREyeOpenness)
    {
        if (previousREyeOpenness == 1.0f && currentREyeOpenness < 1.0f)
        {
            childObject.transform.SetParent(null);
            positionSetThisBlink = false;

            blinkCount++;
        }
    }
    private void DetectBlinking()
    {
        float currentLEyeOpenness = 0;
        float currentREyeOpenness = 0;
        PXR_MotionTracking.GetEyeOpenness(ref currentLEyeOpenness, ref currentREyeOpenness);

        // Check for a blink in the left eye
        if (previousLEyeOpenness == 1.0f && currentLEyeOpenness < 1.0f)
        {
        
                SelectObject = true;
            //childObject.transform.position = parentObject.position;
            if (!positionSetThisBlink )
            {
                parentObject.transform.LookAt(childObject.transform);
                positionSetThisBlink = true; // Set the flag to true for this blink


            }

            if (parentObject.childCount > 0)
            {
                // If yes, remove the existing child
                Transform existingChild = parentObject.GetChild(0);
                existingChild.SetParent(null);
              
            }
            childObject.transform.SetParent(parentObject);
            //  childObject.transform.parent = transform;
            //  childObject.transform.parent = transform;
            //  Reset the position, rotation, and scale of the childObject to match the parent
            //  issue that it does not follow gazing 
            //  childObject.transform.localPosition = Vector3.zero;
            childObject.transform.localRotation = Quaternion.identity;
  
            blinkCount++;

        }

        // Check for a blink in the right eye
        if (previousREyeOpenness == 1.0f && currentREyeOpenness < 1.0f)
        {
          
                childObject.transform.SetParent(null);
                positionSetThisBlink = false; // Reset the flag for this blink
            
                blinkCount++;
        }

        // Update the previous eye openness values for the next frame
        previousLEyeOpenness = currentLEyeOpenness;
        previousREyeOpenness = currentREyeOpenness;

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
    void CheckHeadsetOrientation_(Matrix4x4 headPoseMatrix)
    {
        // Extract the rotation component from the head pose matrix
        Quaternion headsetRotation = headPoseMatrix.rotation;

        // You can now check the headset's rotation to determine if it's facing up or down.
        // For example, you can check the dot product with an "up" vector to see if it's facing upward.
        float dotProduct = Vector3.Dot(headsetRotation * Vector3.forward, Vector3.up);
        Debug.Log(dotProduct);

        if (dotProduct > 0.5f)
        {
            transform.Translate(transform.forward * 0.15f * Time.deltaTime);
            // The headset is facing upward.
            Debug.Log("Headset is facing upward.");
        }
        else if (dotProduct < -0.5f)
        {
            transform.Translate(transform.forward * -0.15f * Time.deltaTime);
            // The headset is facing downward.
            Debug.Log("Headset is facing downward.");
        }
    }
    void CheckHeadsetOrientation(Matrix4x4 headPoseMatrix)
    {
        Quaternion cameraRotation = xrCamera.transform.rotation;

        // Determine the pitch (tilt) of the camera by extracting the X-axis rotation
        float pitch = cameraRotation.eulerAngles.x;

      //  transform.position = Vector3.Lerp(transform.position, xrCamera.transform.position * -1f, Time.deltaTime * 0.15f);
        transform.Translate(transform.forward * -0.15f * Time.deltaTime);
        // You can now use the 'pitch' value to check if the camera is looking up or down
        if (pitch > 45.0f)
        {
            // The camera is looking up
            Debug.Log("Looking up");
        //   transform.Translate(xrCamera.transform.forward * 0.15f*Time.deltaTime);
        //    transform.position = Vector3.Lerp(transform.position, xrCamera.transform.position , Time.deltaTime * 0.15f);

            //   transform.position = Vector3.MoveTowards(transform.position, xrCamera.transform.position * -1, 2 * Time.deltaTime);
        }
        else if (pitch < -45.0f)
        {
            // The camera is looking down
            Debug.Log("Looking down");
          //    transform.Translate(xrCamera.transform.forward * -0.15f * Time.deltaTime);
       //     transform.position = Vector3.Lerp(transform.position , xrCamera.transform.position * -1f, Time.deltaTime * 0.15f);
            // transform.position = Vector3.MoveTowards(transform.position, xrCamera.transform.position, 2 * Time.deltaTime);
        }
        else
        {
            // The camera is relatively level
            Debug.Log("Looking straight ahead");
        }
    }
}
