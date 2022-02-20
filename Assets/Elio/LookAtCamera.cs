using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script by Elio
public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Will make the sprite always look at the camera and if it doesn't know what camera is it will find the camera
        if (cam != null)
        {
            transform.LookAt(cam.transform, Vector3.up);
        }
        else
        {
            cam = FindObjectOfType<Camera>().gameObject;
        }
        
    }
}
