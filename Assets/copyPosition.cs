using UnityEngine;

public class copyPosition : MonoBehaviour
{
    public Transform target; // Drag and drop the target object in the Inspector

    void Update()
    {
        if (target != null)
        {
            // Copy the position of the target object
            transform.position = target.position;
        }
    }
}
