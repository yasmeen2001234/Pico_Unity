using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.XR;

public class Move_ZAxis : MonoBehaviour
{
    bool triggerValue;
    Transform secondChild;
    // Start is called before the first frame update
    void Start()
    {
        
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

    void MoveZAxis()
    {
        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            //      secondChild.transform.Translate(0.5f * Time.deltaTime * transform.forward);
            secondChild.transform.Translate(0.5f * Time.deltaTime * transform.TransformDirection(Vector3.forward));
            Debug.Log("Current Position: " + secondChild.transform.position);
            Debug.Log("Current Forward: " + secondChild.transform.forward);
          //  secondChild.transform.Translate(secondChild.transform.position.x, secondChild.transform.position.y, 0.5f);

        }  if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.secondaryButton, out triggerValue) && triggerValue)
        {
           // secondChild.transform.Translate(-0.5f * Time.deltaTime * transform.forward);
          //  secondChild.transform.Translate(secondChild.transform.position.x, -0.5f, secondChild.transform.position.z);
            secondChild.transform.Translate(-0.5f * Time.deltaTime * transform.TransformDirection(Vector3.forward));

        }
      
    }
}
