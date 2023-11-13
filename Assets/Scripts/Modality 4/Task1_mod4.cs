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

    public float distanceThreshold = 2.0f;
    public static bool allTorusClose = false; // New boolean variable
    float blueDistance;
    float yellowDistance;
    float redDistance;
    float greenDistance;

    public List<GameObject> objectsWithGrabInteractable;
    
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
        blueDistance = Vector3.Distance(blueTorus.transform.position, blue_torus_clone.position);
        yellowDistance = Vector3.Distance(yellowTorus.transform.position, yellow_torus_clone.position);
        redDistance = Vector3.Distance(redTorus.transform.position, red_torus_clone.position);
        greenDistance = Vector3.Distance(greenTorus.transform.position, green_torus_clone.position);

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

    void SnapTorus()
    {
        if (blueDistance <= distanceThreshold)
        {
          
            blueTorus.transform.SetPositionAndRotation(blue_torus_clone.position, blue_torus_clone.rotation);
            DestroyingXRGrab(0);

            ScriptRemover.DestroyAllScripts(blueTorus);
        }

        if (redDistance <= distanceThreshold)
        {
            redTorus.transform.SetPositionAndRotation(red_torus_clone.position, red_torus_clone.rotation);
            DestroyingXRGrab(1);
            ScriptRemover.DestroyAllScripts(redTorus);
        }
        if (greenDistance <= distanceThreshold)
        {
            greenTorus.transform.SetPositionAndRotation(green_torus_clone.position, green_torus_clone.rotation);
            DestroyingXRGrab(2);
            ScriptRemover.DestroyAllScripts(greenTorus);
        }

        if (yellowDistance <= distanceThreshold)
        {
            yellowTorus.transform.SetPositionAndRotation(yellow_torus_clone.position, yellow_torus_clone.rotation);
            DestroyingXRGrab(3);
            ScriptRemover.DestroyAllScripts(yellowTorus);
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
