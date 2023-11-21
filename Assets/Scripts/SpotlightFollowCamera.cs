using UnityEngine;

public class SpotlightFollowCamera : MonoBehaviour
{
    public Transform spotlightTransform;
    public float speed = 5f;

    void Update()
    {
        if (spotlightTransform != null)
        {
            // Calculate the direction to the spotlight
            Vector3 direction = spotlightTransform.position - transform.position;

            // Normalize the direction vector to get a unit vector
            direction.Normalize();

            // Move the object towards the spotlight
            transform.position += direction * speed * Time.deltaTime;

            // Optionally, make the object look at the spotlight
      //      transform.LookAt(spotlightTransform);
        }
    }
}
