using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public AudioClip ShootSound;
    public AudioSource audioSource;

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
        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range))
          {
          if(Ammo > 0)
            {
                print(hit.transform.name);

                TrailRenderer Trail = Instantiate(BulletTrail, TrailStart.transform.position, Quaternion.Euler(Cam.transform.forward));
                StartCoroutine(SpawnTrail(Trail, hit));

                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
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
        yield return null;
        yield return new WaitForSeconds(Reloadtime);
        Ammo = MagSize;
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
