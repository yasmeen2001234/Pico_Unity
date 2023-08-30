using Tobii.XR.Examples;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    private Vector3 previousPosition;

    public Mod4_Task1_timer Mod4_Task1_timer;
    private void Start()
    {
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (gameObject.layer == LayerMask.NameToLayer("object"))
        {
            if (transform.position != previousPosition)
            {
                Debug.Log("Position has changed!");
                Mod4_Task1_timer.StartTimer();
                // Do something when the position changes
            }

            previousPosition = transform.position;
        }
    }
}
