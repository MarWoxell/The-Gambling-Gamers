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
        //G�r s� att man b�rjar med ett fullt magasin
        Ammo = MagSize;
        WeaponManager = GetComponent<WeaponsMaster>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public virtual void Fire()
    {
        //Skickar ut en raycast fr�n kameran
        RaycastHit hit;
        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range, ~mask))
          {
          if(Ammo > 0)
            {
                //Allt visuella sker h�r. Det spelas ett ljud, spriten �ndras och en lysande bullettrail skickas ut.
                audioSource.PlayOneShot(ShootSound);
                this.StartCoroutine(Animation());
                TrailRenderer Trail = Instantiate(BulletTrail, TrailStart.transform.position, Quaternion.Euler(Cam.transform.forward));
                GameObject Light = Instantiate(LightSource, TrailStart.transform.position, Quaternion.Euler(Cam.transform.forward));
                Light.transform.parent = Trail.transform;

                StartCoroutine(SpawnTrail(Trail, hit));

                //Raycasten checkar vad den kolliderar med. Den g�r skada ifall den prickar en fiende, g�r dubbel skada ifall den prickar ett huvud och f�rst�r projektilen ifall den prickar en.
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
                //Om magasinet �r tomt/om man trycker p� R s� b�rjar reloaden
                StartCoroutine(Reload());
            }
        }
    }
    public IEnumerator Reload()
    {
        //Aktiverar en variabel f�r att undvika stacking av reloads, aktiverar en ljudeffekt och en promt och sedan g�r magasinet fullt och deaktiverar variabeln s� att man kan ladda om igen.
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
        //Flashar skjutspriten i en halv sekund och sedan �terv�nder till en idlesprite. Man skulle ha kunnat anv�nda en animator med vi hade problem med animationstr�det.
        yield return null;
        WeaponRenderer.sprite = FireSprite;
        yield return new WaitForSeconds(0.5f);
        WeaponRenderer.sprite = IdleSprite;
    }
    public IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        //G�r s� att trailen tar sig fr�n startpositionen till st�llet man prickar p� en sekund och efter det s� f�rst�rs trailen.
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
        //G�r s� att skadan �kar linj�rt med vapenleveln.
        Damage = BaseDamage + (5 * (WeaponLVL - 1 ));
    }
}
