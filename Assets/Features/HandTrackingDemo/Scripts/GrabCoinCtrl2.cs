
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(Collider))]
public class GrabCoinCtrl2 : MonoBehaviour
{
    private enum ObjGrabState
    {
        None,
        Waiting,
        Falling,
        Grabbed,
        End,
    }

    public float lerpSpeed = 5f;
    public float currDistance = 0f;
    public float maxDistance = 0f;
    public float releaseMargin = 1.3f;
    public int currCoinValue = 0;
  

    private Rigidbody rb;
    private ObjGrabState currState = ObjGrabState.Waiting;
    private int fingers = 0;
    private float fallTime = 0f;
    private bool indexFinger = false;
    private bool thumbFinger = false;
    private FingerTipCtrl thumbCtrl;
    public Transform indexTransform;
    //public FingerTipCtrl indexCtrl;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        currState = ObjGrabState.Waiting;
    }

    private void OnEnable()
    {
       // ArcadeManager.instance.CoinGrabbed = false;
        fallTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (currState == ObjGrabState.Grabbed)
            Follow();
        if(currState == ObjGrabState.Falling)
        {
            //incase the coin falls through the world, give it a timer to reset itself
            fallTime += Time.deltaTime;
            currState = ObjGrabState.Waiting;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        
           //Coin is waiting to be grabbed
            //Check for fingers entering its trigger area to star the coin grabbed logic logic
            if (other.CompareTag("Index") && !indexFinger)
            {
                indexFinger = true;
                fingers++;
                indexTransform = other.transform;
                if (fingers >= 2)
                {
                    GrabLogic();
                    fingers = 2;
                }
            }
            if (other.CompareTag("Thumb") && !thumbFinger)
            {
                thumbFinger = true;
                fingers++;
                thumbCtrl = other.GetComponent<FingerTipCtrl>();
                if (fingers >= 2)
                {
                    GrabLogic();
                    fingers = 2;
                }
            
        }
    }

    //check for fingers leaving the trigger area
    private void OnTriggerExit(Collider other)
    {
        if(currState == ObjGrabState.Waiting)
        {
            if (other.CompareTag("Index") && indexFinger)
            {
                indexFinger = false;
                fingers--;
                if (fingers < 0)
                    fingers = 0;

            }
            if (other.CompareTag("Thumb") && thumbFinger)
            {
                thumbFinger = false;
                fingers--;
                if (fingers < 0)
                    fingers = 0;

            }
        }
    }


    //Once grabbed, go through this logic to set up functionality. reset the coins falltime, change the state to grabbed
    //maxDistance determines the exact distance between the finger the initial grabbed occured at so we know how to set up the release distance
    private void GrabLogic()
    {
        if(fingers >= 2 && currState == ObjGrabState.Waiting)
        {
            currState = ObjGrabState.Grabbed;
            fallTime = 0f;
            maxDistance = Vector3.Distance(indexTransform.position, thumbCtrl.transform.position);
         //   ArcadeManager.instance.CoinGrabbed = true;

           
        }
    }

    //Once we grab the coin, have the coin follow the position that is stored in thumbCtrl called objectSetPos. This is an offset positon manually set under the thumb parent
    private void Follow()
    {
        currDistance = Vector3.Distance(indexTransform.position, thumbCtrl.transform.position);

        if (currDistance > maxDistance * releaseMargin)
           
           Fall();
        else
        {
           // transform.position = Vector3.Lerp(transform.position, thumbCtrl.objectSetPos.position, Time.deltaTime * lerpSpeed * 2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, thumbCtrl.objectSetPos.rotation, Time.deltaTime * lerpSpeed);
        }
    }

    //we have let go of the coin, turn the gravity on to allow the coin to drop and possibly score on a hat
    public void Fall()
    {
    //    rb.useGravity = true;
      //  rb.isKinematic = false;
      currState = ObjGrabState.Falling; // cannot grab object again

      //  currState = ObjGrabState.Waiting; object is sticked to the finger

      //  currState = ObjGrabState.End; // // cannot grab object again

    }
   
}
