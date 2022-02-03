using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWeapon : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        Ammo = MagSize;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public virtual void Fire()
    {
        audioSource.PlayOneShot(ShootSound, 1F);
        RaycastHit hit;

 
        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range, ~mask))
            
          {
          if(Ammo > 0)
            {
                audioSource.PlayOneShot(ShootSound);
                this.StartCoroutine(Animation());
                TrailRenderer Trail = Instantiate(BulletTrail, TrailStart.transform.position, Quaternion.Euler(Cam.transform.forward));
                GameObject Light = Instantiate(LightSource, TrailStart.transform.position, Quaternion.Euler(Cam.transform.forward));
                Light.transform.parent = Trail.transform;

                StartCoroutine(SpawnTrail(Trail, hit));

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
                StartCoroutine(Reload());
            }
        }
    }
    public IEnumerator Reload()
    {
        IsReloading = true;
        Ammo = 0;
        yield return null;
        ReloadText.text = "Reloading...";
        audioSource.PlayOneShot(ReloadSound);
        yield return new WaitForSeconds(Reloadtime);
        ReloadText.text = "";
        Ammo = MagSize;
        IsReloading = false;
    }
    public virtual IEnumerator Animation()
    {
        print("normal");
        yield return null;
        WeaponRenderer.sprite = FireSprite;
        yield return new WaitForSeconds(0.5f);
        WeaponRenderer.sprite = IdleSprite;
    }
    public IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
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
        Damage = BaseDamage + (5 * (WeaponLVL - 1 ));
    }
}
