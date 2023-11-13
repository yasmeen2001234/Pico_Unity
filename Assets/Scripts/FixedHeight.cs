using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class FixedHeight : MonoBehaviour
{
    [SerializeField]
    GameObject VRHeadSet;
    bool triggerValue;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
     //   VRHeadSet.transform.position.y = 1; //0.5f 
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.secondaryButton, out triggerValue) && triggerValue)
        {
            transform.Translate(Vector3.up * 0.35f * Time.deltaTime);
        }

        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            transform.Translate(Vector3.down * 0.35f * Time.deltaTime);
        }
    }
}
