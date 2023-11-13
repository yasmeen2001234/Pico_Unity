using UnityEngine;

public class Task2_Mod3 : MonoBehaviour
{
    [Header("Blue Cube")]
    [SerializeField] Transform blue_Cube_clone;
    [SerializeField] GameObject blueCube;

    [Header("Yellow Cube")]
    [SerializeField] Transform yellow_Cube_clone;
    [SerializeField] GameObject yellowCube;

    [Header("Green Cube")]
    [SerializeField] Transform green_Cube_clone;
    [SerializeField] GameObject greenCube;

    [Header("Hand Grab script")]
    public GrabbingWithYas grabbingScriptBlue;
    public GrabbingWithYas grabbingScriptYellow;
    public GrabbingWithYas grabbingScriptgreen;

    public float distanceThreshold = 2.0f;
    public static bool allCubeClose = false; // New boolean variable


    float blueDistance;
    float yellowDistance;
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
        greenDistance = Vector3.Distance(greenCube.transform.position, green_Cube_clone.position);

        // Check if all distances are within the threshold
        if (blueDistance <= distanceThreshold &&
            yellowDistance <= distanceThreshold &&
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
        if (blueDistance <= distanceThreshold )
        {
            if(grabbingScriptBlue.IsHandGrabbed)

            {
                blueCube.transform.SetPositionAndRotation(blue_Cube_clone.position, blue_Cube_clone.rotation);
                grabbingScriptBlue.enabled = false;
            }
           
            else grabbingScriptBlue.enabled = true;


           
        }
        
        if (greenDistance <= distanceThreshold)
        {
            grabbingScriptgreen.enabled = false;
            greenCube.transform.SetPositionAndRotation(green_Cube_clone.position, green_Cube_clone.rotation);
        } else grabbingScriptgreen.enabled = true;

        if (yellowDistance <= distanceThreshold)
        {
            grabbingScriptYellow.enabled = false;
            yellowCube.transform.SetPositionAndRotation(yellow_Cube_clone.position, yellow_Cube_clone.rotation);
        }
        else grabbingScriptYellow.enabled = true;

    }
}
