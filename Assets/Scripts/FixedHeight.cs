using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FixedHeight : MonoBehaviour
{
    [SerializeField]
    GameObject VRHeadSet;
    // Start is called before the first frame update
    void Start()
    {
     //   VRHeadSet.transform.position.y = 1; //0.5f 
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
