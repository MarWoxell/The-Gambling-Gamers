using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
