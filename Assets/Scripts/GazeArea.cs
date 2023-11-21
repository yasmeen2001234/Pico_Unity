using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeArea : MonoBehaviour
{
    public Light spotLight_;
    // Start is called before the first frame update
    void Start()
    {
        spotLight_.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.name == "gazeArea")
        {
            spotLight_.enabled = true;
            Debug.Log("Enter gaze area " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "gazeArea")
        {
            spotLight_.enabled = false;
            Debug.Log("Exit gaze area " + other.name);
        }
    }
}
