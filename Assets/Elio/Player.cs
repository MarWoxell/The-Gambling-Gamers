using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int money;
    public int realMoney;
    public int maxHealth = 100;
    public int moneyAmount;
    public int damage = 10;
    
    public hpsliderscript healthBar; 
    public AudioSource PlayerAudio;
    public AudioClip PickupSound;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.playerhp = maxHealth;
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
        if (other.gameObject.tag == "HealthPack")
        {
            healthBar.heal(30);
            Destroy(other.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            healthBar.playerhp -= damage;
            healthBar.takedamage(damage);
            print("HealthChange");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        print(money);
        if (healthBar.playerhp <= 0)
        {
            hpsliderscript.isDead = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            healthBar.deadoverlay.SetActive(true);
            //SceneManager.LoadScene();
        }
        else
        {
            hpsliderscript.isDead = false;  
        }

    }
}
