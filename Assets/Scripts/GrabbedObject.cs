using UnityEngine;

public class GrabbedObject : MonoBehaviour
{
    private Transform handTransform;
    private Vector3 initialOffset;

    // Set the hand transform and initial offset
    public void SetGrabbed(Transform hand, Vector3 offset)
    {
        handTransform = hand;
        initialOffset = offset;
    }

    // Update the grabbed object's transform to follow the hand
    private void Update()
    {
        if (handTransform != null)
        {
            // Update the position relative to the hand with the initial offset
            transform.position = handTransform.position + initialOffset;
            transform.rotation = handTransform.rotation;
        }
    }
}