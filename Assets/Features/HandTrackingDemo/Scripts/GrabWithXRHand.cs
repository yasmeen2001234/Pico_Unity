using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWithXRHand : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject directInteractor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grab_()
    {
        transform.position = Vector3.Lerp(transform.position, directInteractor.transform.position, Time.deltaTime * 2 * 2f);
        transform.rotation = Quaternion.Lerp(transform.rotation, directInteractor.transform.rotation, Time.deltaTime * 2);
    }
}
