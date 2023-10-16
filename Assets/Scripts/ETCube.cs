using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Pico;
using Unity.XR.PXR;
using UnityEngine.XR;

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
        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            targetRenderer.material.color = HighLightColor;

        }

        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            childObject.transform.SetParent(parentObject);
        }
        else childObject.transform.SetParent(null);
        //  else transform.position = originalPos;

        /* newPosition = new Vector3(spot.position.x, spot.position.y, transform.position.z);
           transform.position = newPosition;*/

    }

    public override void IsFocused()
    {
        base.IsFocused();
        focusing = true;
        //  childObject.transform.SetParent(parentObject);
        targetRenderer.material.color = HighLightColor;
    }

    public override void UnFocused()
    {
        base.UnFocused();
        focusing = false;
        //   childObject.transform.SetParent(null);
        targetRenderer.material.color = originColor;
    }
}
