using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.PXR;
using static Unity.XR.PXR.PXR_Input;

public class CheckActiveState : MonoBehaviour
{

    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;

    [SerializeField] GameObject leftHandControllers;
    [SerializeField] GameObject rightHandControllers;

    [SerializeField] Text debug_t;

    public List<Collider> collidersToSetAsTrigger = new List<Collider>();

    public Controller controllerType;
    // Start is called before the first frame update
    void Start()
    {
        leftHandControllers.SetActive(true);
        rightHandControllers.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
   

        if (PXR_HandTracking.GetActiveInputDevice() == ActiveInputDevice.HandTrackingActive)
        {
            leftHand.SetActive(true);
            rightHand.SetActive(true);
            leftHandControllers.SetActive(false);
            rightHandControllers.SetActive(false);
            foreach (Collider collider in collidersToSetAsTrigger)
            {
                collider.isTrigger = true;
                collider.enabled = true;
            }
            debug_t.text = "Hands Active";

        } else if(PXR_HandTracking.GetActiveInputDevice() == ActiveInputDevice.ControllerActive)
        {
            foreach (Collider collider in collidersToSetAsTrigger)
            {
                collider.isTrigger = false;
                collider.enabled = false;
            }
            leftHandControllers.SetActive(true);
            rightHandControllers.SetActive(true);
            leftHand.SetActive(false);
            rightHand.SetActive(false);

            debug_t.text = "Controller Active";
        }

        if(IsControllerConnected(controllerType))
        {
            Debug.Log("Controller " + (controllerType == Controller.LeftController ? "Left" : "Right") + " is connected.");
          //  debug_t.text = controllerType == Controller.LeftController ? "Left" : "Right";
        }

        if (ActiveInputDevice.ControllerActive.Equals("ControllerActive"))
        {
            Debug.Log(ActiveInputDevice.ControllerActive);
        }


    }
    /*
    void CheckActive()
    {

        // Get the active input device
        PXR_HandTracking.InputDevice inputDevice = PXR_Controller.GetActiveInputDevice();

        // Check the active input device type
        switch (inputDevice)
        {
            case Pvr_Controller.InputDevice.HeadActive:
                Debug.Log("Active Input Device: HMD (Head-mounted Display)");
                // Handle HMD-specific logic here
                break;
            case Pvr_Controller.InputDevice.ControllerActive:
                Debug.Log("Active Input Device: Controllers");
                // Handle controller-specific logic here
                break;
            case Pvr_Controller.InputDevice.HandTrackingActive:
                Debug.Log("Active Input Device: Hands");
                // Handle hand tracking-specific logic here
                break;
            default:
                Debug.Log("Active Input Device: Unknown");
                // Handle the case when the active input device is unknown or not recognized
                break;
        }
    */
    }

