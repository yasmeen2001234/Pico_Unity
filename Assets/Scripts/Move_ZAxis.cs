using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.XR;

public class Move_ZAxis : MonoBehaviour
{
    bool triggerValue;
    Transform secondChild;

    public GameObject XR_Origin;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Get the parent transform
        Transform parentTransform = transform;

        // Check if the parent has at least two children
        if (parentTransform.childCount >= 2)
        {
            // Get the second child
             secondChild = parentTransform.GetChild(1);

            // Do something with the second child
         //   Debug.Log("Second child name: " + secondChild.name);

            MoveZAxis();
        }
        else
        {
            // Handle the case where there are not enough children
          //  Debug.LogWarning("Parent does not have at least two children.");
        }
    }
    public void ResetObjectPosition()
    {
        // Reset the position to the initial position
        transform.position = initialPosition;

       // XR_Origin.transform.LookAt(transform);
    }

    public void SpotLightLookAt()
    {
        // Reset the position to the initial position
      //  transform.position = initialPosition;
        transform.LookAt(XR_Origin.transform);
    }
    void MoveZAxis()
    {
        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            ResetObjectPosition();


        } 
        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.secondaryButton, out triggerValue) && triggerValue)
        {
            // secondChild.transform.Translate(-0.5f * Time.deltaTime * transform.forward);
            //  secondChild.transform.Translate(secondChild.transform.position.x, -0.5f, secondChild.transform.position.z);
            //  secondChild.transform.Translate(-0.5f * Time.deltaTime * transform.TransformDirection(Vector3.forward));
         //   SpotLightLookAt();
        }
        
      
    }
}
