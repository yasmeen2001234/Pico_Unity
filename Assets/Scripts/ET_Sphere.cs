using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Events;
using Tobii.XR;
using UnityEngine.UIElements;

public class ET_Sphere : ETObject
{
    public GameObject parentObject; // Reference to the parent GameObject
    public GameObject childObject;  // Reference to the child GameObject
    // Start is called before the first frame update
    Transform sourceTransform;
    Transform parentObjectTransform;
    public Text checkText;
    private const ControllerButton TriggerButton = ControllerButton.Trigger;

    private bool focusing = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         sourceTransform = childObject.transform;
         parentObjectTransform = parentObject.transform;

        // Copy the position from the source to the destination object.
      //  parentObjectTransform.position = sourceTransform.position;

        /*  if(focusing || ControllerManager.Instance.GetButtonPress(TriggerButton))
          {
              sourceTransform.position =  parentObjectTransform.position;
          }
          else sourceTransform.position = sourceTransform.position;

          checkText.text = focusing.ToString();
        */
        sourceTransform.position = parentObjectTransform.position;

    }

    public override void IsFocused()
    {
        base.IsFocused();
        focusing = true;
      

    }

    public override void UnFocused()
    {
        base.UnFocused();
        focusing = false;
        sourceTransform.position = sourceTransform.position;

    }
}
