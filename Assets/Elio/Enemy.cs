using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Enemy loses health by subtracting amount - Rustam
    public void TakeDamage(int amount)
    {
        health -= amount;
    }

        // Update is called once per frame
        void Update()
    {
        if(health <= 0)
        {
            SpawnEnemy.areThereEnemiesAlive--;
            Destroy(this.gameObject);
        }
    }
}
