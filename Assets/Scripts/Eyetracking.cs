using UnityEngine;
using Unity.XR.PXR;


public class Eyetracking : MonoBehaviour
    {
    private Vector3 EyePosition;
    private Vector3 EyeVector;
    public GameObject box;
    Vector3 leftEyeGazePosition = Vector3.zero;

    void Start()
        {
        //    PXR_EyeTracking.GetCombineEyeGazeVector(out Vector3 vector);
      //  PXR_EyeTracking.Create();
    }

        void Update()
        {

        //     PXR_EyeTracking.GetCombineEyeGazePoint(out Vector3 EyePosition);
        //    PXR_EyeTracking.GetCombineEyeGazeVector(out Vector3 EyeVector);
        PXR_EyeTracking.GetLeftEyePositionGuide(out Vector3 EyeVector);
        PXR_EyeTracking.GetRightEyePositionGuide(out Vector3 EyePosition);

        //    Debug.Log("Left eye position: " + leftEyePosition);

        RaycastHit hitInfo1;

      

        if (Physics.Raycast(EyeVector, Camera.main.transform.forward, out hitInfo1) )
        {
            if (hitInfo1.collider.gameObject == box )
            {
                box.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                box.GetComponent<Renderer>().material.color = Color.blue;
            }
        }

        RaycastHit hitInfo2;

        if ( Physics.Raycast(EyePosition, Camera.main.transform.forward, out hitInfo2))
        {
            if ( hitInfo2.collider.gameObject == box)
            {
                box.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                box.GetComponent<Renderer>().material.color = Color.blue;
            }
        }



    }
}

