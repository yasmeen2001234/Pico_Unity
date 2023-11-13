using UnityEngine;

public class SpotlightFollowCamera : MonoBehaviour
{
    public Transform cameraToFollow;
    public float distanceFromCamera = 5f; // adjust this distance as needed

    void Update()
    {
        if (cameraToFollow != null)
        {
            // Set the position of the spotlight to be a certain distance behind the camera
            transform.position = cameraToFollow.position - cameraToFollow.forward * distanceFromCamera;

            // Make the spotlight look at the camera
            transform.LookAt(cameraToFollow);
        }
        else
        {
            Debug.LogWarning("Camera to follow is not assigned!");
        }
    }
}
