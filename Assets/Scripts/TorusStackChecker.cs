using UnityEngine;

public class TorusStackChecker : MonoBehaviour
{
    [Header("Blue Torus")]
    [SerializeField] Transform blueTorus;

    [Header("Yellow Torus")]
    [SerializeField] Transform yellowTorus;

    [Header("Red Torus")]
    [SerializeField] Transform redTorus;

    [Header("Green Torus")]
    [SerializeField] Transform greenTorus;

    public float verticalThreshold = 0.2f; // Threshold for vertical alignment
    public static bool allTorusClose = false; // New boolean variable
    private void Update()
    {
        CheckTorusStack();
    }

    void CheckTorusStack()
    {
        bool isStacked = true;

        if (!AreTorusStacked(blueTorus, yellowTorus) ||
            !AreTorusStacked(yellowTorus, redTorus) ||
            !AreTorusStacked(redTorus, greenTorus))
        {
            isStacked = false;
        }

        if (isStacked)
        {
            Debug.Log("Torus are stacked in order: Blue, Yellow, Red, Green");
            // Add additional logic here when torus are stacked correctly.
            allTorusClose = true;
        }
        else
        {
            Debug.Log("Torus are not stacked correctly.");
        }
    }

    bool AreTorusStacked(Transform upperTorus, Transform lowerTorus)
    {
        float distance = Mathf.Abs(upperTorus.position.y - lowerTorus.position.y);
        return distance <= verticalThreshold;
    }
}
