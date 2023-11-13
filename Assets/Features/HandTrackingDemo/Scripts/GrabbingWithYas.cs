using System.Collections;
using System.Collections.Generic;
using Tobii.XR.Examples;
using UnityEngine;
using UnityEngine.UI;
using Pico;
using Unity.XR.PXR;
public class GrabbingWithYas : MonoBehaviour
{
    [SerializeField] FingerTipCtrl thumbCtrlL;

    [SerializeField] FingerTipCtrl thumbCtrlR;


    bool isLeftGrabbed = false;

    bool isRightGrabbed = false;


    public Text isGrabbing_;
    public float lerpSpeed = 5f;

    public Transform thumbL; // Reference to the first game object
    public Transform indexL; // Reference to the second game object

    public Transform thumbR; // Reference to the first game object
    public Transform indexR; // Reference to the second game object

    float distancel = 0;
    float distanceR = 0;
    public bool IsHandGrabbed => isLeftGrabbed || isRightGrabbed;

    public Mod3_Task1_timer Mod3_Task1_timer_;
    public Mod3_Task2_timer Mod3_Task2_timer_;
    public Mod4_Task1_timer Mod4_Task1_timer_;
    public Mod4_Task2_timer Mod4_Task2_timer_;

    bool Timer1 = true;
    bool Timer2 = true;


    bool snapping = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         distancel = Vector3.Distance(thumbL.position, indexL.position);

        distanceR = Vector3.Distance(thumbR.position, indexR.position);
    
        if (isLeftGrabbed && distancel < 0.09f)
        {
            isRightGrabbed = false;
            FollowLeftHand();

        }
        else
        {
            isLeftGrabbed = false;
        }
    
        if (isRightGrabbed && distanceR < 0.09f)
        {
            isLeftGrabbed = false;
            FollowRightHand();

        }
        else
        {
            isRightGrabbed = false;
        }


        isGrabbing_.text = (isRightGrabbed.ToString() + " "+ isLeftGrabbed.ToString() + " L Distance is " + distancel + " and R distance " + distanceR );
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IndexL") || other.CompareTag("ThumbL"))
        {
            isLeftGrabbed = true;
            isRightGrabbed = false;
        }

        if (other.CompareTag("IndexR") || other.CompareTag("ThumbR"))
        {
        
            isRightGrabbed = true;
            isLeftGrabbed = false;
        }
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Index") || other.CompareTag("Thumb") ) // if && it sticks to finger , if || its keeps triggering true/false
        {
          //  isGrabbed = false;

        }
    }


    private void GrabLogic()
    {
       
            
           
           // maxDistance = Vector3.Distance(indexTransform.position, thumbCtrl.transform.position);
            //   ArcadeManager.instance.CoinGrabbed = true;


        
    }

    private void FollowLeftHand()
    {
        StartingTimer();
        transform.position = Vector3.Lerp(transform.position, thumbCtrlL.objectSetPos.position, Time.deltaTime * lerpSpeed * 2f);
        transform.rotation = Quaternion.Lerp(transform.rotation, thumbCtrlL.objectSetPos.rotation, Time.deltaTime * lerpSpeed);
    }
    private void FollowRightHand()
    {
        StartingTimer();
        transform.position = Vector3.Lerp(transform.position, thumbCtrlR.objectSetPos.position, Time.deltaTime * lerpSpeed * 2f);
        transform.rotation = Quaternion.Lerp(transform.rotation, thumbCtrlR.objectSetPos.rotation, Time.deltaTime * lerpSpeed);
    }



    public void StartingTimer()
    {
        if (Mod3_Task1_timer_ != null && Timer1)
        {
            Timer1 = false;
            Mod3_Task1_timer_.StartTimer();

        } else if(Mod3_Task2_timer_ !=null && Timer2)
        {
            Timer2 = false;
            Mod3_Task2_timer_.StartTimer();
        }

        else if (Mod4_Task1_timer_ != null)
            Mod4_Task1_timer_.StartTimer();

        else if (Mod4_Task2_timer_ != null)
            Mod4_Task2_timer_.StartTimer();
    }

}