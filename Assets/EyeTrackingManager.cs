using UnityEngine;
using UnityEngine.UI;
using Unity.XR.PXR;
using Pose = Unity.XR.PXR.Pose;

public class EyeTrackingManager : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public GameObject objectToMove; // Reference to the GameObject you want to move
    public PxrVector3f position;
    public PxrVector4f orientation;
    public PXR_MotionTracking motionTracking;

    public Text posText;
    private void Update()
    {
        EyeTrackingMode eyeTrackingMode = EyeTrackingMode.PXR_ETM_NONE;
        TrackingStateCode trackingState;

        EyeTrackingStartInfo Startinfo = new EyeTrackingStartInfo();
        Startinfo.needCalibration = 1;
        Startinfo.mode = eyeTrackingMode;
        trackingState = (TrackingStateCode)PXR_MotionTracking.StartEyeTracking(ref Startinfo);


    
        // Get eye tracking data
       
        //    EyeTrackingData eyeTrackingData = new EyeTrackingData();
        //     TrackingStateCode trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingData(ref info, ref eyeTrackingData);
        EyeTrackingStartInfo info = new EyeTrackingStartInfo();
        info.needCalibration = 1;
        info.mode = eyeTrackingMode;
        trackingState = (TrackingStateCode)PXR_MotionTracking.StartEyeTracking(ref info);

        Pose pose = new Pose();

        Vector3 eyePosition = new(pose.position.x, pose.position.y, objectToMove.transform.position.z);

        // Get the position of the left eye
        /*
        Vector3 eyePosition = new Vector3(eyeTrackingData.eyeDatas[(int)PerEyeUsage.LeftEye].pose.position.x,
                                              eyeTrackingData.eyeDatas[(int)PerEyeUsage.LeftEye].pose.position.y,
                                              eyeTrackingData.eyeDatas[(int)PerEyeUsage.LeftEye].pose.position.z);
        */
        // Move your GameObject based on eye position

       // pose.position = new PxrVector3f(1.0f, 2.0f, 3.0); // Replace with your desired values
       // pose.orientation = new PxrVector4f(0.1f, 0.2f, 0.3f, 0.4f); // Replace with your desired values


        EyeTrackingDataGetInfo eyeTrackingDataGetInfo = new EyeTrackingDataGetInfo();
        eyeTrackingDataGetInfo.displayTime = 0;
        eyeTrackingDataGetInfo.flags = EyeTrackingDataGetFlags.PXR_EYE_DEFAULT
                    | EyeTrackingDataGetFlags.PXR_EYE_POSITION
                    | EyeTrackingDataGetFlags.PXR_EYE_ORIENTATION;
        EyeTrackingData eyeTrackingData = new EyeTrackingData();
        trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingData(ref eyeTrackingDataGetInfo, ref eyeTrackingData);



        EyePupilInfo eyePupilInfo = new EyePupilInfo();

      






        int EyeNEW =     PXR_MotionTracking.GetEyeTrackingData(ref eyeTrackingDataGetInfo, ref eyeTrackingData);
        int pupilMo = PXR_MotionTracking.GetEyePupilInfo(ref eyePupilInfo);
        Debug.Log(eyePosition);
        Debug.Log(EyeNEW);
        Debug.Log(pupilMo);


        Vector3 leftEyePosition = new Vector3(eyeTrackingData.eyeDatas[0].pose.position.x, eyeTrackingData.eyeDatas[0].pose.position.y, eyeTrackingData.eyeDatas[0].pose.position.z);
        Vector3 rightEyePosition = new Vector3(eyeTrackingData.eyeDatas[1].pose.position.x, eyeTrackingData.eyeDatas[1].pose.position.y, eyeTrackingData.eyeDatas[1].pose.position.z);


        posText.text =  leftEyePosition.ToString();

        /* ALL returned 0 */

        /*
        unsafe
        {
            Debug.Log(eyePupilInfo.leftEyePupilPosition[2]);
            posText.text = eyePupilInfo.leftEyePupilPosition[2].ToString();
        }
        */
        // posText.text = PXR_Plugin.MotionTracking.UPxr_GetEyePupilInfo(ref eyePupilInfo).ToString();
        //  posText.text = eyePupilInfo.leftEyePupilPosition.ToString();
        // posText.text = eyePupilInfo.leftEyePupilDiameter  + " pupilMo " + pupilMo + " EyeNEW " + EyeNEW + " eyePosition  " + eyePosition;
        if (objectToMove != null) 
            {
                float speed = movementSpeed * Time.deltaTime;
                objectToMove.transform.position = eyePosition * speed;
            }
      
    }

 
}
