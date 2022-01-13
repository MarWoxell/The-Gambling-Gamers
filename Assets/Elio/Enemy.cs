using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int areThereEnemiesAlive;
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
    }

        // Update is called once per frame
        void Update()
    {
        if(health <= 0)
        {
            areThereEnemiesAlive--;
        }
    }
}
