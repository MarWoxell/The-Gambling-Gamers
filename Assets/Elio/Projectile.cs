using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 playerPosition;
    public GameObject player;
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
        /*playerPosition = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * projectileSpeed);*/
    }
}
