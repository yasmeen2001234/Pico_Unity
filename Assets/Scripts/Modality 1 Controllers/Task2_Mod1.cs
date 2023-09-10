using UnityEngine;

public class Task2_Mod1 : MonoBehaviour
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
    float blueDistance;
    float yellowDistance;
    float redDistance;
    float greenDistance;

    private void Start()
    {
    }
    private void Update()
    {
        CheckDistances();
        SnapCubes();
    }

    void CheckDistances()
    {

        blueDistance = Vector3.Distance(blueCube.transform.position, blue_Cube_clone.position);
        yellowDistance = Vector3.Distance(yellowCube.transform.position, yellow_Cube_clone.position);
        redDistance = Vector3.Distance(redCube.transform.position, red_Cube_clone.position);
        greenDistance = Vector3.Distance(greenCube.transform.position, green_Cube_clone.position);

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

    void SnapCubes()
    {
        if (blueDistance <= distanceThreshold)
        {
            blueCube.transform.SetPositionAndRotation(blue_Cube_clone.position, blue_Cube_clone.rotation);
        }

        if (redDistance <= distanceThreshold)
        {
            redCube.transform.SetPositionAndRotation(red_Cube_clone.position, red_Cube_clone.rotation);
        }
        if (greenDistance <= distanceThreshold)
        {
            greenCube.transform.SetPositionAndRotation(green_Cube_clone.position, green_Cube_clone.rotation);
        }

        if (yellowDistance <= distanceThreshold)
        {
            yellowCube.transform.SetPositionAndRotation(yellow_Cube_clone.position, yellow_Cube_clone.rotation);
        }

    }
}
