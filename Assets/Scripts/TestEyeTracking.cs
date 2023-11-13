using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.UI;
public class TestEyeTracking : MonoBehaviour
{
    EyeTrackingDataGetInfo _eyeTrackingDataGetInfo;
    EyePupilInfo _eyePupilPosition;
    EyeTrackingData _eyeTrackingData;

    [SerializeField] Text _eyeTrackingText1;
    [SerializeField] Text _eyeTrackingText2;

    // Start is called before the first frame update
    void Start()
    {
        TrackingStateCode trackingState = (TrackingStateCode)PXR_MotionTracking.WantEyeTrackingService();

        EyeTrackingMode eyeTrackingMode = EyeTrackingMode.PXR_ETM_BOTH;
        bool supported = false;
        int supportedModesCount = 0;
        trackingState = (TrackingStateCode)PXR_MotionTracking.GetEyeTrackingSupported(ref supported, ref supportedModesCount, ref eyeTrackingMode);

        EyeTrackingStartInfo info = new EyeTrackingStartInfo();
        info.needCalibration = 0;
        info.mode = eyeTrackingMode;
        trackingState = (TrackingStateCode)PXR_MotionTracking.StartEyeTracking(ref info);

        _eyeTrackingDataGetInfo = new EyeTrackingDataGetInfo();
        _eyeTrackingDataGetInfo.displayTime = 0;
        _eyeTrackingDataGetInfo.flags = EyeTrackingDataGetFlags.PXR_EYE_DEFAULT
            | EyeTrackingDataGetFlags.PXR_EYE_POSITION
            | EyeTrackingDataGetFlags.PXR_EYE_ORIENTATION;

        _eyeTrackingData = new EyeTrackingData();
    }

    void Update()
    {
        //Pupil info
        PXR_MotionTracking.GetEyePupilInfo(ref _eyePupilPosition);
        Debug.Log(_eyePupilPosition.ToString());
       // _eyeTrackingText1.text = _eyePupilPosition.ToString();
        //Gaze info
        PXR_MotionTracking.GetEyeTrackingData(ref _eyeTrackingDataGetInfo, ref _eyeTrackingData);
        Debug.Log(_eyeTrackingData.ToString());
        _eyeTrackingText2.text = _eyeTrackingData.ToString();
    }


}
