using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//rustam

public class bobing : MonoBehaviour
{
    public Vector3 Startposition;
    public float Speed;
    public float Distance;
    float Delay;
    bool DelayOver = false;
    float StartPoint;
    // Start is called before the first frame update
    void Start()
    {
        Startposition = transform.position;
        Delay = Random.Range(0, 4f);
        StartCoroutine(Bobwait());
        StartPoint = Random.Range(-3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (DelayOver == true)
        {
            Bob();
        }
    }
    public virtual void Bob()
    {
        transform.position = Startposition + new Vector3(0f, Mathf.Sin( StartPoint +Speed * Time.time) * Distance, 0f);
        //Adderar en sinusvåg upp och ner i y positionen i en sinusvåg till startpositionen.
    }
    IEnumerator Bobwait()
    {
        yield return new WaitForSeconds(Delay);
        DelayOver = true;
    }
}
