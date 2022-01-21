using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//rustam

public class bobing : MonoBehaviour
{
    public Vector3 Startposition;
    public float Speed;
    public float Distance;
    public float Apex;
    // Start is called before the first frame update
    void Start()
    {
        Startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Bob();
        //Kallar på voiden varje frame.
    }
    public virtual void Bob()
    {
        transform.position = Startposition + new Vector3(0f, Mathf.Sin(Speed * Time.time) * Distance, 0f);
        //Adderar en sinusvåg upp och ner i y positionen i en sinusvåg till startpositionen.
    }
}
