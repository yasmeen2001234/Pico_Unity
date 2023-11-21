using UnityEngine;

public class SpotlightCheck : MonoBehaviour
{
    public Light lightSource;

    void Update()
    {
        RaycastHit hit;
        Vector3 direction = (lightSource.transform.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == lightSource.gameObject)
            {
                Debug.Log("Object is illuminated by the light source.");
            }
            else
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
                Debug.Log("Object is not illuminated by the light source.");
            }
        }
    }
}
