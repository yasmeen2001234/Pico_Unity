using UnityEngine;

public class Task2_Mod2 : MonoBehaviour
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


    [Header("Components")]
    public GameObject[] targetObjects;

    public float distanceThreshold = 2.0f;
    public static bool allCubeClose = false; // New boolean variable

    float blueDistance;
    float yellowDistance;
    float greenDistance;

    private void Update()
    {
        CheckDistances();
        SnapCubes();
    }

    void CheckDistances()
    {
      

        blueDistance = Vector3.Distance(new Vector3(blueCube.transform.position.x, blueCube.transform.position.y, 0), new Vector3(blue_Cube_clone.position.x, blue_Cube_clone.position.y, 0));
        yellowDistance = Vector3.Distance(new Vector3(yellowCube.transform.position.x, yellowCube.transform.position.y, 0), new Vector3(yellow_Cube_clone.position.x, yellow_Cube_clone.position.y, 0));
        greenDistance = Vector3.Distance(new Vector3(greenCube.transform.position.x, greenCube.transform.position.y, 0), new Vector3(green_Cube_clone.position.x, green_Cube_clone.position.y, 0));

        // Check if all distances are within the threshold
        if (blueDistance <= distanceThreshold &&
            yellowDistance <= distanceThreshold &&
            greenDistance <= distanceThreshold)
        {
            allCubeClose = true;
            Debug.Log("All Cube are close to their clones!");
            if (targetObjects != null)
            {
                foreach (GameObject obj in targetObjects)
                {
                    RemoveAllScripts(obj);
                }
            }
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

    void RemoveAllScripts(GameObject gameObject)
    {
        // Get all the components attached to the target GameObject
        Component[] components = gameObject.GetComponents<Component>();

        // Iterate through the components and remove the scripts
        foreach (var component in components)
        {
            if (component is MonoBehaviour && component != this)
            {
                Destroy(component);
            }
        }
    }
}
