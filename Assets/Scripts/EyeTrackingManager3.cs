using UnityEngine;
using Unity.XR.PXR;
using UnityEngine.XR;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class EyeTrackingManager3 : MonoBehaviour
{
    public Transform Origin;
    public GameObject SpotLight;

    private Vector3 combineEyeGazeVector;
    private Vector3 combineEyeGazeOriginOffset;
    private Vector3 combineEyeGazeOrigin;
    private Matrix4x4 headPoseMatrix;
    private Matrix4x4 originPoseMatrix;

    private Vector3 combineEyeGazeVectorInWorldSpace;
    private Vector3 combineEyeGazeOriginInWorldSpace;

    private Vector2 primary2DAxis;

    private RaycastHit hitinfo;

    private Transform selectedObj;

    private bool wasPressed;
    TrackingStateCode trackingState;

    bool alignRotation = false;
    private bool supported = false;
    void Start()
    {
        combineEyeGazeOriginOffset = Vector3.zero;
        combineEyeGazeVector = Vector3.zero;
        combineEyeGazeOrigin = Vector3.zero;
        originPoseMatrix = Origin.localToWorldMatrix;
        trackingState = (TrackingStateCode)PXR_MotionTracking.WantEyeTrackingService();
        // Query if the current device supports eye tracking
        EyeTrackingMode eyeTrackingMode = EyeTrackingMode.PXR_ETM_NONE;
        int supportedModesCount = 0;
        trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingSupported(ref supported, ref supportedModesCount, ref eyeTrackingMode);
    }

    void Update()
    {
        if (supported)
        {

            //Offest Adjustment
            if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxis))
            {

                combineEyeGazeOriginOffset.x += primary2DAxis.x * 0.001f;
                combineEyeGazeOriginOffset.y += primary2DAxis.y * 0.001f;

            }

            PXR_EyeTracking.GetHeadPosMatrix(out headPoseMatrix);

            bool isSuccess = PXR_EyeTracking.GetCombineEyeGazeVector(out combineEyeGazeVector);
            if (!isSuccess) return;

            PXR_EyeTracking.GetCombineEyeGazePoint(out combineEyeGazeOrigin);
            //Translate Eye Gaze point and vector to world space
            combineEyeGazeOrigin += combineEyeGazeOriginOffset;
            combineEyeGazeOriginInWorldSpace = originPoseMatrix.MultiplyPoint(headPoseMatrix.MultiplyPoint(combineEyeGazeOrigin));
            combineEyeGazeVectorInWorldSpace = originPoseMatrix.MultiplyVector(headPoseMatrix.MultiplyVector(combineEyeGazeVector));

            if (SpotLight != null)
            {
                 SpotLight.transform.position = combineEyeGazeOriginInWorldSpace;

                       //  SpotLight.transform.rotation = Quaternion.LookRotation(combineEyeGazeVectorInWorldSpace, Vector3.up);
                      //  SpotLight.transform.rotation = Camera.main.transform.rotation;
                     //  SpotLight.transform.rotation = Camera.main.transform.rotation;
                    //  SpotLight.transform.LookAt(Camera.main.transform);
                   //  SpotLight.transform.rotation = Camera.main.transform.rotation;
                


                    // Calculate the target rotation based on gazing
                    Quaternion targetRotation = Quaternion.LookRotation(combineEyeGazeVectorInWorldSpace, Vector3.up);

                    // Interpolate between the camera rotation and the target rotation
                    float rotationSpeed = 2f;  // Adjust the speed of interpolation as needed
                    SpotLight.transform.rotation = Quaternion.Slerp(SpotLight.transform.rotation, targetRotation, rotationSpeed);
                
            }

            GazeTargetControl(combineEyeGazeOriginInWorldSpace, combineEyeGazeVectorInWorldSpace);

            CheckHeadsetOrientation(headPoseMatrix);
        }
        else
        {
            GazeTargetControl(Camera.main.transform.position, Camera.main.transform.forward);
        }

    }

    void CheckHeadsetOrientation(Matrix4x4 headPoseMatrix)
    {
        // Extract the rotation component from the head pose matrix
        Quaternion headsetRotation = headPoseMatrix.rotation;

        // You can now check the headset's rotation to determine if it's facing up or down.
        // For example, you can check the dot product with an "up" vector to see if it's facing upward.
        float dotProduct = Vector3.Dot(headsetRotation * Vector3.forward, Vector3.up);

        if (dotProduct > 0.7f)
        {
            // The headset is facing upward.
            Debug.Log("Headset is facing upward.");
        }
        else if (dotProduct < -0.7f)
        {
            // The headset is facing downward.
            Debug.Log("Headset is facing downward.");
        }
    }
    void GazeTargetControl(Vector3 origin, Vector3 vector)
    {
        if (Physics.SphereCast(origin, 0.15f, vector, out hitinfo))
        {
            if (selectedObj != null && selectedObj != hitinfo.transform)
            {
                if (selectedObj.GetComponent<ETObject>() != null)
                    selectedObj.GetComponent<ETObject>().UnFocused();
                selectedObj = null;
            }
            else if (selectedObj == null)
            {
                selectedObj = hitinfo.transform;
                if (selectedObj.GetComponent<ETObject>() != null)
                    selectedObj.GetComponent<ETObject>().IsFocused();
            }

        }
        else
        {
            if (selectedObj != null)
            {
                if (selectedObj.GetComponent<ETObject>() != null)
                    selectedObj.GetComponent<ETObject>().UnFocused();
                selectedObj = null;
            }
        }
    }
}
