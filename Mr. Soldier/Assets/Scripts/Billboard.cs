using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //Where's the camera?
    public Transform cam;


    void LateUpdate()
    {
        //Face the Health System UI towards the camera
        transform.LookAt(transform.position + cam.forward);
    }
}
