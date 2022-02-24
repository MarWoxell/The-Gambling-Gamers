using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
//Script by Elio
public class Player : MonoBehaviour
{
    public int realMoney;
    public int maxHealth = 100;
    public int moneyAmount;
    public int damage = 10;
    public float maxVignette = 0.7f;
    public float minVignette = 0.4f;
    public float interpolationPoint;
    public bool invincibility;
    public float vignetteIntensity;
    public bool vignetteGoUp;

    public PostProcessVolume volume;
    Vignette vignette;
    public hpsliderscript healthBar; 
    public AudioSource PlayerAudio;
    public AudioClip PickupSound;
    public AudioClip OuchSound;

    IEnumerator InvincibilityFrame()
    {
        /*Makes the player invincible and turns the vignette up, waits for one second, then makes vignette start to go down, 
        then waits for one second, then turns off invincibility*/
        invincibility = true;
        vignetteGoUp = true;
        yield return new WaitForSecondsRealtime(1);
        vignetteGoUp = false;
        yield return new WaitForSecondsRealtime(1);
        invincibility = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        vignette = volume.profile.GetSetting<Vignette>();
        invincibility = false;
        healthBar.playerhp = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void OnTriggerEnter(Collider other)
    {
        //If the player touches money then money will go up and a pickup sound will be played, then the money object is destroyed
        if (other.gameObject.tag == "Money")
        {
            SaveObject.instance.money += moneyAmount;
            PlayerAudio.PlayOneShot(PickupSound);
            Destroy(other.gameObject);
        }
        //If the player touches a healthpack then health will go up and a pickup sound will be played, then the healthpack object is destroyed
        if (other.gameObject.tag == "HealthPack")
        {
            healthBar.heal(30);
            PlayerAudio.PlayOneShot(PickupSound);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "OutOfBounds")
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        //If the player gets hit by a projectile while they aren't invincible then they take damage, their healthbar is lowered, they say ouch and becomes invincible
        if (collision.collider.tag == "Projectile" && invincibility == false || collision.collider.tag == "ShankEnemy" && invincibility == false)
        {
            healthBar.playerhp -= damage;
            healthBar.takedamage(damage);
            PlayerAudio.PlayOneShot(OuchSound);
            StartCoroutine(InvincibilityFrame());
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*Makes sure that interpolationPoint can't go over or under 0-1 and changes the vignette point based on vignetteIntensity 
        which in turn is based on the interpolationPoint*/
        interpolationPoint = Mathf.Clamp(interpolationPoint, 0, 1);
        vignette.intensity.value = vignetteIntensity;
        vignetteIntensity = Mathf.Lerp(minVignette, maxVignette, interpolationPoint);
        
        //Makes the vignette go up and down when you take damage
        if(invincibility == true && vignetteIntensity <= 0.7f && vignetteIntensity >= 0.4f)
        {
            if(vignetteGoUp == true)
            {
                print("What");
                interpolationPoint += 0.2f;
            }
            if(vignetteGoUp == false)
            {
                interpolationPoint -= 0.08f;
            }
        }

        print(SaveObject.instance.money);

        //If you're dead then the death screen will pop up and you can move you mouse again
        if (healthBar.playerhp <= 0)
        {
            hpsliderscript.isDead = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            healthBar.deadoverlay.SetActive(true);
        }
        else
        {
            hpsliderscript.isDead = false;  
        }

    }
}
