using UnityEngine;

public class Task1 : MonoBehaviour
{
    [Header("Blue Torus")]
    [SerializeField] Transform blue_torus_clone; // The target GameObject to check distance against.
    [SerializeField] GameObject blueTorus;


    [Header("Yellow Torus")]
    [SerializeField] Transform yellow_torus_clone; // The target GameObject to check distance against.
    [SerializeField] GameObject yellowTorus;



    [Header("Red Torus")]
    [SerializeField] Transform red_torus_clone; // The target GameObject to check distance against.
    [SerializeField] GameObject redTorus;



    [Header("Green Torus")]
    [SerializeField] Transform green_torus_clone; // The target GameObject to check distance against.
    [SerializeField] GameObject greenTorus;


    public float distanceThreshold = 0f; // The distance threshold to consider as "close".

    private void Update()
    {
        Blue_torus();
        Yellow_torus();
        Red_torus();
        Green_torus();
    }


    void Blue_torus()
    {
        // Calculate the distance between this GameObject's position and the target's position.
        float distance = Vector3.Distance(blueTorus.transform.position, blue_torus_clone.position);

        // Check if the distance is within the threshold.
        if (distance <= distanceThreshold)
        {
            Debug.Log("Objects are close!");
            // You can add additional actions or logic here when the objects are close.
        }
    }

    void Yellow_torus()
    {
        // Calculate the distance between this GameObject's position and the target's position.
        float distance = Vector3.Distance(yellowTorus.transform.position, yellow_torus_clone.position);

        // Check if the distance is within the threshold.
        if (distance <= distanceThreshold)
        {
            Debug.Log("Objects are close!");
            // You can add additional actions or logic here when the objects are close.
        }
    }
    void Red_torus()
    {
        // Calculate the distance between this GameObject's position and the target's position.
        float distance = Vector3.Distance(redTorus.transform.position, red_torus_clone.position);

        // Check if the distance is within the threshold.
        if (distance <= distanceThreshold)
        {
            Debug.Log("Objects are close!");
            // You can add additional actions or logic here when the objects are close.
        }
    }
    void Green_torus()
    {
        // Calculate the distance between this GameObject's position and the target's position.
        float distance = Vector3.Distance(greenTorus.transform.position, green_torus_clone.position);

        // Check if the distance is within the threshold.
        if (distance <= distanceThreshold)
        {
            Debug.Log("Objects are close!");
            // You can add additional actions or logic here when the objects are close.
        }
    }
}