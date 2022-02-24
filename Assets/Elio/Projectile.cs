using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Script by Elio
    public GameObject player;
    public float projectileSpeed;

    public void OnCollisionEnter(Collision collision)
    {
        //Destroys the projectile if it heits the player
        if (collision.collider.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //Destroys the projectile after 5 seconds
        Destroy(this.gameObject, 5);
    }
    public void DestroyProjectile()
    {
        //Destroys the projectile
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //Makes the projectile go towards the player based on it's speed
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
        /*playerPosition = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * projectileSpeed);*/
    }
}
