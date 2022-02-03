using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRotate : MonoBehaviour
{
    public Vector3 RotatePoint;
    public int RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(RotatePoint, Vector3.up, RotateSpeed * Time.deltaTime);
    }
}
