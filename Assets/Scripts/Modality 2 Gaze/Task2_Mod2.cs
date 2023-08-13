using UnityEngine;

public class Task2_Mod2 : MonoBehaviour
{
    [Header("Blue Cube")]
    [SerializeField] Transform blue_Cube_clone;
    [SerializeField] GameObject blueCube;

    [Header("Yellow Cube")]
    [SerializeField] Transform yellow_Cube_clone;
    [SerializeField] GameObject yellowCube;

    [Header("Red Cube")]
    [SerializeField] Transform red_Cube_clone;
    [SerializeField] GameObject redCube;

    [Header("Green Cube")]
    [SerializeField] Transform green_Cube_clone;
    [SerializeField] GameObject greenCube;

    public float distanceThreshold = 2.0f;
    public static bool allCubeClose = false; // New boolean variable

    private void Update()
    {
        CheckDistances();
    }

    void CheckDistances()
    {
        float blueDistance = Vector3.Distance(blueCube.transform.position, blue_Cube_clone.position);
        float yellowDistance = Vector3.Distance(yellowCube.transform.position, yellow_Cube_clone.position);
        float redDistance = Vector3.Distance(redCube.transform.position, red_Cube_clone.position);
        float greenDistance = Vector3.Distance(greenCube.transform.position, green_Cube_clone.position);

        // Check if all distances are within the threshold
        if (blueDistance <= distanceThreshold &&
            yellowDistance <= distanceThreshold &&
            redDistance <= distanceThreshold &&
            greenDistance <= distanceThreshold)
        {
            allCubeClose = true;
            Debug.Log("All Cube are close to their clones!");
            // You can add additional actions or logic here when all Cube are close.
        }
        else
        {
            allCubeClose = false;
        }
    }
}
