using Tobii.XR.Examples;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    private Vector3 previousPosition;

    public Mod4_Task1_timer Mod4_Task1_timer;
   public Mod4_Task2_timer Mod4_Task2_timer;
    private void Start()
    {
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (gameObject.CompareTag("Mod4_1"))
        {
            if (transform.position != previousPosition)
            {
                Debug.Log("Position has changed!");
                Mod4_Task1_timer.StartTimer();
                // Do something when the position changes
            }

            previousPosition = transform.position;
        }

        if (gameObject.CompareTag("Mod4_2"))
        {
            if (transform.position != previousPosition)
            {
                Debug.Log("Position has changed!");
                Mod4_Task2_timer.StartTimer();
                // Do something when the position changes
            }

            previousPosition = transform.position;
        }
    }
}
