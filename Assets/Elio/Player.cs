using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class Player : MonoBehaviour
{
    //public static int money;
    public int realMoney;
    public int maxHealth = 100;
    public int moneyAmount;
    public int damage = 10;
    public float maxVignette = 0.7f;
    public float minVignette = 0.4f;
    public float interpolationPoint;
    public bool invincibility;
    public bool vignetteGoUp;

    public PostProcessVolume volume;
    Vignette vignette;
    public float vignetteIntensity;
    public hpsliderscript healthBar; 
    public AudioSource PlayerAudio;
    public AudioClip PickupSound;
    public AudioClip OuchSound;

    IEnumerator InvincibilityFrame()
    {
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
        if (other.gameObject.tag == "Money")
        {
            SaveObject.instance.money += moneyAmount;
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
        if (collision.collider.tag == "Projectile" && invincibility == false)
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
        interpolationPoint = Mathf.Clamp(interpolationPoint, 0, 1);
        vignette.intensity.value = vignetteIntensity;
        vignetteIntensity = Mathf.Lerp(minVignette, maxVignette, interpolationPoint);
        
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
