using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;
public class DetectHandController : MonoBehaviour
{
    [SerializeField] Collider obj_TORUS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (PXR_Input.IsControllerConnected(PXR_Input.Controller.LeftController) && PXR_Input.IsControllerConnected(PXR_Input.Controller.RightController))
        {
            Debug.Log("Controllers are connected.");
            obj_TORUS.isTrigger = false;
        }
        else
        {
            Debug.Log("Controllers are disconnected.");
            obj_TORUS.isTrigger = true;
        }


    }
}
