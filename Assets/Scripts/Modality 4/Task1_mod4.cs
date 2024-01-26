using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Task1_mod4 : MonoBehaviour
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

    [Header("Spotlight")]
    [SerializeField] Transform spotlight;
   


    public float distanceThreshold = 2.0f;
    public static bool allTorusClose = false; // New boolean variable
    float blueDistance;
    float yellowDistance;
    float redDistance;
    float greenDistance;


    float blueDistanceGaze;
    float yellowDistanceGaze;
    float redDistanceGaze;
    float greenDistanceGaze;

    public List<GameObject> objectsWithGrabInteractable;
    
    private void Start()
    {

    }
    private void Update()
    {
        //  Transform myTransform = spotlight;
        CheckDistances();
        // Check if the object has exactly two children
        if (spotlight.childCount == 2)
        {
          //  Debug.Log("This object has two children.");
          SnapTorusGaze();
        }
        else
        {
          
           SnapTorus();
          //  Debug.Log("This object does not have two children.");
        }
    

    }

    void CheckDistances()
    {
        blueDistance = Vector3.Distance(blueTorus.transform.position, blue_torus_clone.position);
        yellowDistance = Vector3.Distance(yellowTorus.transform.position, yellow_torus_clone.position);
        redDistance = Vector3.Distance(redTorus.transform.position, red_torus_clone.position);
        greenDistance = Vector3.Distance(greenTorus.transform.position, green_torus_clone.position);

       
        blueDistanceGaze = Vector3.Distance(new Vector3(blueTorus.transform.position.x, blueTorus.transform.position.y, 0), new Vector3(blue_torus_clone.position.x, blue_torus_clone.position.y, 0));
        yellowDistanceGaze = Vector3.Distance(new Vector3(yellowTorus.transform.position.x, yellowTorus.transform.position.y, 0), new Vector3(yellow_torus_clone.position.x, yellow_torus_clone.position.y, 0));
        redDistanceGaze = Vector3.Distance(new Vector3(redTorus.transform.position.x, redTorus.transform.position.y, 0), new Vector3(red_torus_clone.position.x, red_torus_clone.position.y, 0));
        greenDistanceGaze = Vector3.Distance(new Vector3(greenTorus.transform.position.x, greenTorus.transform.position.y, 0), new Vector3(green_torus_clone.position.x, green_torus_clone.position.y, 0));
        
        
        // Check if all distances are within the threshold

        if (blueDistance <= distanceThreshold &&
            yellowDistance <= distanceThreshold &&
            redDistance <= distanceThreshold &&
            greenDistance <= distanceThreshold)
        {
            allTorusClose = true;
            Debug.Log("All torus are close to their clones!");
            // You can add additional actions or logic here when all torus are close.
        }
        else
        {
            allTorusClose = false;
        }
    }
    void SnapTorusGaze()
    {
        if (blueDistanceGaze <= distanceThreshold)
        {

            blueTorus.transform.SetPositionAndRotation(blue_torus_clone.position, blue_torus_clone.rotation);
            DestroyingXRGrab(0);
            blueTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(blueTorus);
        }

        if (redDistanceGaze <= distanceThreshold)
        {
            redTorus.transform.SetPositionAndRotation(red_torus_clone.position, red_torus_clone.rotation);
            DestroyingXRGrab(1);
            redTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(redTorus);
        }
        if (greenDistanceGaze <= distanceThreshold)
        {
            greenTorus.transform.SetPositionAndRotation(green_torus_clone.position, green_torus_clone.rotation);
            DestroyingXRGrab(2);
            greenTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(greenTorus);
        }

        if (yellowDistanceGaze <= distanceThreshold)
        {
            yellowTorus.transform.SetPositionAndRotation(yellow_torus_clone.position, yellow_torus_clone.rotation);
            DestroyingXRGrab(3);
            yellowTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(yellowTorus);
        }

    }
    void SnapTorus()
    {
        if (blueDistance <= distanceThreshold)
        {
          
            blueTorus.transform.SetPositionAndRotation(blue_torus_clone.position, blue_torus_clone.rotation);
            DestroyingXRGrab(0);
            blueTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(blueTorus);
        }

        if (redDistance <= distanceThreshold)
        {
            redTorus.transform.SetPositionAndRotation(red_torus_clone.position, red_torus_clone.rotation);
            DestroyingXRGrab(1);
            redTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(redTorus);
        }
        if (greenDistance <= distanceThreshold)
        {
            greenTorus.transform.SetPositionAndRotation(green_torus_clone.position, green_torus_clone.rotation);
            DestroyingXRGrab(2);
            greenTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(greenTorus);
        }

        if (yellowDistance <= distanceThreshold)
        {
            yellowTorus.transform.SetPositionAndRotation(yellow_torus_clone.position, yellow_torus_clone.rotation);
            DestroyingXRGrab(3);
            yellowTorus.transform.parent = null;
            ScriptRemover.DestroyAllScriptsAfterDelay(yellowTorus);
        }

    }

    public void DestroyingXRGrab(int index)
    {
        if (index >= 0 && index < objectsWithGrabInteractable.Count)
        {
            // Get the GameObject at the specified index.
            GameObject obj = objectsWithGrabInteractable[index];

            // Get a reference to the XRGrabInteractable component on the GameObject.
            XRGrabInteractable grabInteractable = obj.GetComponent<XRGrabInteractable>();

            // Check if the component exists and remove it.
            if (grabInteractable != null)
            {
                Destroy(grabInteractable);
            }
        }
    }
 
}
