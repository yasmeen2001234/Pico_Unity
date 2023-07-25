using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;

public class SeeThrough : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSeeThrough", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSeeThrough()
    {
        PXR_Boundary.EnableSeeThroughManual(true);
    }
}
