using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Task2_Mod4 : MonoBehaviour
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


    [Header("Spotlight")]
    [SerializeField] Transform spotlight;


    public float distanceThreshold = 2.0f;
    public static bool allCubeClose = false; // New boolean variable


    float blueDistance;
    float yellowDistance;
    float greenDistance;


    float blueDistanceGaze;
    float yellowDistanceGaze;
    float greenDistanceGaze;
    private void Update()
    {
     //   CheckDistances();
    //    SnapCubes();

        CheckDistances();
        // Check if the object has exactly two children
        if (spotlight.childCount == 2)
        {
            Debug.Log("This object has two children.");
            SnapCubesGaze();
        }
        else
        {

            SnapCubes();
            Debug.Log("This object does not have two children.");
        }
    }

    void CheckDistances()
    {
         blueDistance = Vector3.Distance(blueCube.transform.position, blue_Cube_clone.position);
         yellowDistance = Vector3.Distance(yellowCube.transform.position, yellow_Cube_clone.position);
         greenDistance = Vector3.Distance(greenCube.transform.position, green_Cube_clone.position);


        blueDistanceGaze = Vector3.Distance(new Vector3(blueCube.transform.position.x, blueCube.transform.position.y, 0), new Vector3(blue_Cube_clone.position.x, blue_Cube_clone.position.y, 0));
        yellowDistanceGaze = Vector3.Distance(new Vector3(yellowCube.transform.position.x, yellowCube.transform.position.y, 0), new Vector3(yellow_Cube_clone.position.x, yellow_Cube_clone.position.y, 0));
        greenDistanceGaze = Vector3.Distance(new Vector3(greenCube.transform.position.x, greenCube.transform.position.y, 0), new Vector3(green_Cube_clone.position.x, green_Cube_clone.position.y, 0));

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
        if (blueDistance <= distanceThreshold)
        {
            
            blueCube.transform.SetPositionAndRotation(blue_Cube_clone.position, blue_Cube_clone.rotation);
            blueCube.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(blueCube);
        }


        
        if (greenDistance <= distanceThreshold)
        {
          
            greenCube.transform.SetPositionAndRotation(green_Cube_clone.position, green_Cube_clone.rotation);
            greenCube.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(greenCube);
        }


        if (yellowDistance <= distanceThreshold)
        {
           
            yellowCube.transform.SetPositionAndRotation(yellow_Cube_clone.position, yellow_Cube_clone.rotation);
            yellowCube.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(yellowCube);
        }

    }

    void SnapCubesGaze()
    {
        if (blueDistanceGaze <= distanceThreshold)
        {

            blueCube.transform.SetPositionAndRotation(blue_Cube_clone.position, blue_Cube_clone.rotation);
            blueCube.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(blueCube);
        }



        if (greenDistanceGaze <= distanceThreshold)
        {

            greenCube.transform.SetPositionAndRotation(green_Cube_clone.position, green_Cube_clone.rotation);
            greenCube.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(greenCube);
        }


        if (yellowDistanceGaze <= distanceThreshold)
        {

            yellowCube.transform.SetPositionAndRotation(yellow_Cube_clone.position, yellow_Cube_clone.rotation);
            yellowCube.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(yellowCube);
        }

    }
}
