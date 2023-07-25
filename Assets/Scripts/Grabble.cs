using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grabble : MonoBehaviour
{
    public GameObject grabbedObjectPrefab;
    private GameObject grabbedObject;
    public Text _observation;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hands")
        {

            // Create the grabbed object as a child of the hand
            grabbedObject = Instantiate(grabbedObjectPrefab, collision.transform);

            // Calculate the offset between the hand and the grabbed object
            Vector3 offset = transform.position - collision.transform.position;

            // Set the grabbed object's script with the hand transform and initial offset
            grabbedObject.GetComponent<GrabbedObject>().SetGrabbed(collision.transform, offset);
            _observation.text = "colliding";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hands"))
        {
            // Destroy the grabbed object
            Destroy(grabbedObject);
        }
    }
}
