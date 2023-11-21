using Tobii.XR.Examples;
using UnityEngine;

public class PositionChangeGaze : MonoBehaviour
{
    private Vector3 previousPosition;

    public Mod2_Task1_timer Mod2_Task1_timer;
   public Mod2_Task2_timer Mod2_Task2_timer;
    private void Start()
    {
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (gameObject.CompareTag("Mod2_1"))
        {
            if (transform.position != previousPosition)
            {
                Debug.Log("Position has changed!");
                Mod2_Task1_timer.StartTimer();
                // Do something when the position changes
            }

            previousPosition = transform.position;
        }

        if (gameObject.CompareTag("Mod2_2"))
        {
            if (transform.position != previousPosition)
            {
                Debug.Log("Position has changed!");
                Mod2_Task2_timer.StartTimer();
                // Do something when the position changes
            }

            previousPosition = transform.position;
        }
    }
}
