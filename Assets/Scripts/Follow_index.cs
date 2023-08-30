using UnityEngine;

public class Follow_index: MonoBehaviour
{
    public Transform target;     // Reference to the Target object
    public Vector3 offset;       // Offset between the Target and Follower

    private void Update()
    {
        if (target != null)
        {
            // Calculate the desired position for the Follower
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move the Follower towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }
    }
}
