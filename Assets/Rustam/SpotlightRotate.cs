using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRotate : MonoBehaviour
{
    public Vector3 RotatePoint;
    public int MinSpeed;
    public int MaxSpeed;
    public int RotateSpeed;
    public bool IsNegative;
    // Start is called before the first frame update
    void Start()
    {
        RotateSpeed = Random.Range(MinSpeed, MaxSpeed);
        if(IsNegative == true)
        {
            RotateSpeed = RotateSpeed * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(RotatePoint, Vector3.up, RotateSpeed * Time.deltaTime);
    }
}
