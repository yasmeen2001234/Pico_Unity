using UnityEngine;

public class Task1_mod3 : MonoBehaviour
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

    public GrabbingWithYas grabbingScriptBlue;
    public GrabbingWithYas grabbingScriptYellow;
    public GrabbingWithYas grabbingScriptGreen;
    public GrabbingWithYas grabbingScriptRed;

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
            grabbingScriptBlue.enabled = false;
            blueTorus.transform.SetPositionAndRotation(blue_torus_clone.position, blue_torus_clone.rotation);
        }
        else grabbingScriptBlue.enabled = true;




        if (redDistance <= distanceThreshold)
        {
            grabbingScriptRed.enabled = false;
            redTorus.transform.SetPositionAndRotation(red_torus_clone.position, red_torus_clone.rotation);
        }
        else grabbingScriptRed.enabled = true;



        if (greenDistance <= distanceThreshold)
        {
            grabbingScriptGreen.enabled = false;
            greenTorus.transform.SetPositionAndRotation(green_torus_clone.position, green_torus_clone.rotation);
        }
        else grabbingScriptGreen.enabled = true;




        if (yellowDistance <= distanceThreshold)
        {
            grabbingScriptYellow.enabled = false;
            yellowTorus.transform.SetPositionAndRotation(yellow_torus_clone.position, yellow_torus_clone.rotation);
        }
        else grabbingScriptYellow.enabled = true;

    }
    void SnapRed()
    {
        if (redDistance <= distanceThreshold)
        {
            redTorus.transform.position = red_torus_clone.position;
            redTorus.transform.rotation = red_torus_clone.rotation;
        }
    }
    void SnapGreen()
    {
        if (blueDistance <= distanceThreshold)
        {
            greenTorus.transform.position = green_torus_clone.position;
            greenTorus.transform.rotation = green_torus_clone.rotation;
        }
    }
    void SnapYellow()
    {
        if (blueDistance <= distanceThreshold)
        {
            yellowTorus.transform.position = yellow_torus_clone.position;
            yellowTorus.transform.rotation = yellow_torus_clone.rotation;
        }
    }
}
