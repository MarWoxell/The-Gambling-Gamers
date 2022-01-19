using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int moneyAmount;
    public AudioSource PlayerAudio;
    public AudioClip PickupSound;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            /*Player.playerHealth -= 10;
            healthBar.ChangeHealth(Player.playerHealth);*/
            Player.money += moneyAmount;
            PlayerAudio.PlayOneShot(PickupSound);
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
