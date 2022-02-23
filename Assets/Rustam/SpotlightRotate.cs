using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rustam
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
        //Randomiserar hastigheten inom en range och gör så att den kan snurra baklänges om variabeln är sann
        RotateSpeed = Random.Range(MinSpeed, MaxSpeed);
        if(IsNegative == true)
        {
            RotateSpeed = RotateSpeed * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Varje frame så roterar den runt en poäng på kartan
        transform.RotateAround(RotatePoint, Vector3.up, RotateSpeed * Time.deltaTime);
    }
}
