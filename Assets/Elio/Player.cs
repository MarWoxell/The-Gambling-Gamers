using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int playerHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            Player.playerHealth -= 10;
            healthBar.ChangeHealth(playerHealth);
            print("HealthChange");
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            print("Dead");
            //SceneManager.LoadScene();
        }

    }
}
