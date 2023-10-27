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
    public Text secText;
    TrackingStateCode trackingState;
    private void Start()
    {
        // Want the eye tracking service for the current app
        trackingState = (TrackingStateCode)PXR_MotionTracking.WantEyeTrackingService();

        // Query if the current device supports eye tracking
        EyeTrackingMode eyeTrackingMode = EyeTrackingMode.PXR_ETM_NONE;
        bool supported = false;
        int supportedModesCount = 0;
        trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingSupported(ref supported, ref supportedModesCount, ref eyeTrackingMode);

        // Get the state of eye tracking
        bool tracking = false;
        EyeTrackingState eyeTrackingState = new EyeTrackingState();
        trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingState(ref tracking, ref eyeTrackingState);
      
        // Start eye tracking
        EyeTrackingStartInfo info = new EyeTrackingStartInfo();
        info.needCalibration = 1;
        info.mode = eyeTrackingMode;
        trackingState = (TrackingStateCode)PXR_MotionTracking.StartEyeTracking(ref info);

    }
    private void Update()
    {
        // Get the state of eye tracking
        trackingState = (TrackingStateCode)PXR_MotionTracking.WantEyeTrackingService();

     
        // Get the state of eye tracking
        bool tracking = false;
        EyeTrackingState eyeTrackingState = new EyeTrackingState();
        trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingState(ref tracking, ref eyeTrackingState);

        // Start eye tracking
        EyeTrackingStartInfo Sinfo = new EyeTrackingStartInfo();
        Sinfo.needCalibration = 1;
        Sinfo.mode = eyeTrackingMode;
        trackingState = (TrackingStateCode)PXR_MotionTracking.StartEyeTracking(ref Sinfo);
        secText.text = "Mode Code " + supportedModesCount;
        EyeTrackingDataGetInfo info = new EyeTrackingDataGetInfo();

        info.displayTime = 0;
        info.flags = EyeTrackingDataGetFlags.PXR_EYE_DEFAULT
                    | EyeTrackingDataGetFlags.PXR_EYE_POSITION
                    | EyeTrackingDataGetFlags.PXR_EYE_ORIENTATION;
        EyeTrackingData eyeTrackingData = new EyeTrackingData();
        trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingData(ref info, ref eyeTrackingData);

        EyePupilInfo pInfo = new EyePupilInfo();
        PXR_MotionTracking.GetEyePupilInfo(ref pInfo);

      
        Pose leftEyePose = eyeTrackingData.eyeDatas[0].pose;
       
        unsafe
        {
            Vector2 leftPupilPos = new Vector2(pInfo.leftEyePupilPosition[0], pInfo.leftEyePupilPosition[1]);
            Vector2 rightPupilPos = new Vector2(pInfo.rightEyePupilPosition[0], pInfo.rightEyePupilPosition[1]);


            Debug.Log("Left Pupil Pos: " + leftPupilPos + "Right Pupil Pos: " + rightPupilPos); // getting ( 0 ,0  ) values 
      
        }

    

    }

}