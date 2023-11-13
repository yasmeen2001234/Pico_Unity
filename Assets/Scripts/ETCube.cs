using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Pico;
using Unity.XR.PXR;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class ETCube : ETObject
{
    public Color HighLightColor;

    private Color originColor;
    bool triggerValue;

    public Transform spot;
    private Renderer targetRenderer;
    bool focusing;
    Vector3 newPosition;
    Vector3 originalPos;

    public Transform parentObject; // Drag and drop the parent GameObject here in the Inspector
    public GameObject childObject;
    private float previousLEyeOpenness = 1.0f;
    private float previousREyeOpenness = 1.0f;
    private int blinkCount = 0;

    private bool positionSetThisBlink = false;
    private Matrix4x4 headPoseMatrix;
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

        DetectBlinking();
     
        if (isFocused)
        {
          
            GetComponent<Renderer>().material.color = Color.red;
        }
        else GetComponent<Renderer>().material.color = Color.green;
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
            if (!positionSetThisBlink)
            {
                parentObject.transform.LookAt(childObject.transform);
                positionSetThisBlink = true; // Set the flag to true for this blink
            }
            CheckHeadsetOrientation(headPoseMatrix);

            childObject.transform.SetParent(parentObject);
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

    void CheckHeadsetOrientation(Matrix4x4 headPoseMatrix)
    {
        Quaternion cameraRotation = xrCamera.transform.rotation;

        // Determine the pitch (tilt) of the camera by extracting the X-axis rotation
        float pitch = cameraRotation.eulerAngles.x;

        // You can now use the 'pitch' value to check if the camera is looking up or down
        if (pitch > 45.0f)
        {
            // The camera is looking up
            Debug.Log("Looking up");
            transform.Translate(Vector3.forward * 0.5f);
        }
        else if (pitch < -45.0f)
        {
            // The camera is looking down
            Debug.Log("Looking down");
            transform.Translate(-Vector3.forward * 0.5f);
        }
        else
        {
            // The camera is relatively level
            Debug.Log("Looking straight ahead");
        }
    }
}
