using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject object1; // cube part
   public GameObject object2;

    public Transform targetObject; // The object to stick to
    public float maxDistance = 0.005f; // The maximum distance to stick to the object

    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetObject.position);
        if (distance <= maxDistance)
        {
            transform.position = targetObject.position; // Set the position to match the target object
            transform.rotation = targetObject.rotation; // Set the rotation to match the target object
        }
    }
}
