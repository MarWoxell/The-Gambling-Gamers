using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int playerHealth;
    public static int money;
    public int realMoney;
    public int maxHealth = 100;
    public int moneyAmount;
    
    public hpsliderscript healthBar; 
    public AudioSource PlayerAudio;
    public AudioClip PickupSound;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Money")
        {
            money += moneyAmount;
            PlayerAudio.PlayOneShot(PickupSound);
            Destroy(other.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            Player.playerHealth -= 10;
            healthBar.takedamage(playerHealth);
            print("HealthChange");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        print(money);
        if (playerHealth <= 0)
        {
            healthBar.deadoverlay.SetActive(true);
            print("Dead");
            //SceneManager.LoadScene();
        }

    }
}
