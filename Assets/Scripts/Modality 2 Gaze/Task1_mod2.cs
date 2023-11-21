using UnityEngine;

public class Task1_mod2 : MonoBehaviour
{
    [Header("Blue Torus")]
    [SerializeField] Transform blue_torus_clone;
    [SerializeField] GameObject blueTorus;

    [Header("Yellow Torus")]
    [SerializeField] Transform yellow_torus_clone;
    [SerializeField] GameObject yellowTorus;

    [Header("Red Torus")]
    [SerializeField] Transform red_torus_clone;
    [SerializeField] GameObject redTorus;

    [Header("Green Torus")]
    [SerializeField] Transform green_torus_clone;
    [SerializeField] GameObject greenTorus;

    [Header("Components")]
    public GameObject[] targetObjects;
    public ET_Objects blueETObjects;
    public ET_Objects greenETObjects;



    public float distanceThreshold = 2.0f;
    public static bool allTorusClose = false; // New boolean variable
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
        SnapTorus();
    }

    void CheckDistances()
    {
        //IGNORE Z-AXIS
        blueDistance = Vector3.Distance(new Vector3(blueTorus.transform.position.x, blueTorus.transform.position.y, 0), new Vector3(blue_torus_clone.position.x, blue_torus_clone.position.y, 0));
        yellowDistance = Vector3.Distance(new Vector3(yellowTorus.transform.position.x, yellowTorus.transform.position.y, 0), new Vector3(yellow_torus_clone.position.x, yellow_torus_clone.position.y, 0));
        redDistance = Vector3.Distance(new Vector3(redTorus.transform.position.x, redTorus.transform.position.y, 0), new Vector3(red_torus_clone.position.x, red_torus_clone.position.y, 0));
        greenDistance = Vector3.Distance(new Vector3(greenTorus.transform.position.x, greenTorus.transform.position.y, 0), new Vector3(green_torus_clone.position.x, green_torus_clone.position.y, 0));

        // Check if all distances are within the threshold
        if (blueDistance <= distanceThreshold &&
            yellowDistance <= distanceThreshold &&
            redDistance <= distanceThreshold &&
            greenDistance <= distanceThreshold)
        {
            allTorusClose = true;
            if (targetObjects != null)
            {
                foreach (GameObject obj in targetObjects)
                {
                    RemoveAllScripts(obj);
                }
            }
            Debug.Log("All torus are close to their clones!");
            // You can add additional actions or logic here when all torus are close.
        }
        else
        {
            allTorusClose = false;
        }
    }

    void SnapTorus()
    {
        if (blueDistance <= distanceThreshold)
        {
            blueTorus.transform.SetPositionAndRotation(blue_torus_clone.position, blue_torus_clone.rotation);
            blueTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(blueTorus);
            
           
        }

        if (redDistance <= distanceThreshold)
        {
            redTorus.transform.SetPositionAndRotation(red_torus_clone.position, red_torus_clone.rotation);
            redTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(redTorus);
        }
        if (greenDistance <= distanceThreshold)
        {
            greenTorus.transform.SetPositionAndRotation(green_torus_clone.position, green_torus_clone.rotation);
            greenTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(greenTorus);
        }

        if (yellowDistance <= distanceThreshold)
        {
            yellowTorus.transform.SetPositionAndRotation(yellow_torus_clone.position, yellow_torus_clone.rotation);
            yellowTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(yellowTorus);
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
