using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Detta skript var skrivet av Rustam
public class BaseWeapon : MonoBehaviour
{
    #region Variabler
    public WeaponsMaster WeaponManager;

    public AudioClip ShootSound;
    public AudioClip ReloadSound;
    public AudioSource audioSource;
    public LayerMask mask;

    public int Damage;
    public int BaseDamage;
    public float Range = 1000;
    public Camera Cam;
    public int MagSize;
    public int Ammo;
    public float Reloadtime;
    public int WeaponLVL = 0;
    public bool WeaponActive;
    public Transform TrailStart;
    public TrailRenderer BulletTrail;
    public GameObject LightSource;
    public bool IsReloading = false;
    public bool StopShoot = false;

    public Sprite IdleSprite;
    public Sprite FireSprite;
    public Image WeaponRenderer;
    public Text ReloadText;
    #endregion
    // Start is called before the first frame update
    public virtual void Start()
    {
        //Gör så att man börjar med ett fullt magasin
        Ammo = MagSize;
        WeaponManager = GetComponent<WeaponsMaster>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public virtual void Fire()
    {
        //Skickar ut en raycast från kameran
        RaycastHit hit;
        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range, ~mask))
          {
          if(Ammo > 0)
            {
                //Allt visuella sker här. Det spelas ett ljud, spriten ändras och en lysande bullettrail skickas ut.
                audioSource.PlayOneShot(ShootSound);
                this.StartCoroutine(Animation());
                TrailRenderer Trail = Instantiate(BulletTrail, TrailStart.transform.position, Quaternion.Euler(Cam.transform.forward));
                GameObject Light = Instantiate(LightSource, TrailStart.transform.position, Quaternion.Euler(Cam.transform.forward));
                Light.transform.parent = Trail.transform;

                StartCoroutine(SpawnTrail(Trail, hit));

                //Raycasten checkar vad den kolliderar med. Den gör skada ifall den prickar en fiende, gör dubbel skada ifall den prickar ett huvud och förstör projektilen ifall den prickar en.
                EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                }
                EnemyHead enemyHead = hit.transform.GetComponent<EnemyHead>();
                if(enemyHead != null)
                {
                    enemyHead.health -= (Damage * 2);
                }

                Projectile projectile = hit.transform.GetComponent<Projectile>();
                if (projectile != null)
                {
                    projectile.DestroyProjectile();
                }
                Ammo--;
            }
              else
            {
                //Om magasinet är tomt/om man trycker på R så börjar reloaden
                StartCoroutine(Reload());
            }
        }
    }
    public IEnumerator Reload()
    {
        //Aktiverar en variabel för att undvika stacking av reloads, aktiverar en ljudeffekt och en promt och sedan gör magasinet fullt och deaktiverar variabeln så att man kan ladda om igen.
        IsReloading = true;
        Ammo = 0;
        ReloadText.text = "Reloading...";
        audioSource.PlayOneShot(ReloadSound);
        yield return new WaitForSeconds(Reloadtime);
        ReloadText.text = "";
        Ammo = MagSize;
        IsReloading = false;
    }
    public virtual IEnumerator Animation()
    {
        //Flashar skjutspriten i en halv sekund och sedan återvänder till en idlesprite. Man skulle ha kunnat använda en animator med vi hade problem med animationsträdet.
        yield return null;
        WeaponRenderer.sprite = FireSprite;
        yield return new WaitForSeconds(0.5f);
        WeaponRenderer.sprite = IdleSprite;
    }
    public IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        //Gör så att trailen tar sig från startpositionen till stället man prickar på en sekund och efter det så förstörs trailen.
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = Hit.point;
        Destroy(Trail.gameObject, Trail.time);
    }
    public virtual void DamageFormula()
    {
        //Gör så att skadan ökar linjärt med vapenleveln.
        Damage = BaseDamage + (5 * (WeaponLVL - 1 ));
    }
}
