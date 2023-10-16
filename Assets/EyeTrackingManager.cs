using UnityEngine;
using Unity.XR.PXR;

public class EyeTrackingManager : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public GameObject objectToMove; // Reference to the GameObject you want to move

    private void Update()
    {
        // Get eye tracking data
        EyeTrackingDataGetInfo info = new EyeTrackingDataGetInfo();
        info.displayTime = 0;
        info.flags = EyeTrackingDataGetFlags.PXR_EYE_DEFAULT | EyeTrackingDataGetFlags.PXR_EYE_POSITION;

    //    EyeTrackingData eyeTrackingData = new EyeTrackingData();
   //     TrackingStateCode trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingData(ref info, ref eyeTrackingData);

        EyeTrackingData eyeTrackingData = new EyeTrackingData();
        // Get eye tracking data
        int trackingState = PXR_MotionTracking.GetEyeTrackingData(ref info, ref eyeTrackingData);

     
            // Get the position of the left eye
            Vector3 eyePosition = new Vector3(eyeTrackingData.eyeDatas[(int)PerEyeUsage.LeftEye].pose.position.x,
                                              eyeTrackingData.eyeDatas[(int)PerEyeUsage.LeftEye].pose.position.y,
                                              eyeTrackingData.eyeDatas[(int)PerEyeUsage.LeftEye].pose.position.z);

            // Move your GameObject based on eye position
            if (objectToMove != null)
            {
                float speed = movementSpeed * Time.deltaTime;
                objectToMove.transform.position = eyePosition * speed;
            }
        
    }
}
