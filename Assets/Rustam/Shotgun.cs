using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon
{
    public int Shellcount;
    public float MaxDev;

    void Start()
    {

        Ammo = MagSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (WeaponLVL > 0 && WeaponActive == true && IsReloading == false && StopShoot == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(FirePause());
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }
        DamageFormula();
    }
    IEnumerator FirePause()
    {
        //Cooldownen startas
        StopShoot = true;
        yield return null;
        Fire();
        //0.25 Sekunder senare slutar cooldownen
        yield return new WaitForSeconds(1f);
        StopShoot = false;
    }
    public override void Fire()
    {
        print("Firing");
        if(Ammo > 0)
        {
            for (int i = 1; i <= Shellcount; i++)
            {
                /*Vector3 ForwardVector = Vector3.forward;
                float Deviation = Random.Range(0f, MaxDev);
                ForwardVector = Quaternion.AngleAxis(Deviation, Vector3.up) * ForwardVector;
                ForwardVector = Cam.transform.rotation * ForwardVector;*/

                /*Vector3 ForwardVector = Cam.transform.forward;
                ForwardVector += MaxDev * (Random.Range(0, 2)) * Cam.transform.right;
                ForwardVector += MaxDev * (Random.Range(0, 2)) * Cam.transform.up;*/

                var v3Offset = transform.up * Random.Range(0.0f, MaxDev);
                v3Offset = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), transform.forward) * v3Offset;
                Vector3 ForwardVector = transform.forward + v3Offset;

                RaycastHit hit;
                if (Physics.Raycast(Cam.transform.position, ForwardVector, out hit, Range, ~mask))
                {
                    StartCoroutine(Animation());
                    audioSource.PlayOneShot(ReloadSound);
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
                    if (enemyHead != null)
                    {
                        enemyHead.health -= (Damage * 2);
                    }

                    Projectile projectile = hit.transform.GetComponent<Projectile>();
                    if (projectile != null)
                    {
                        projectile.DestroyProjectile();
                    }
                    
                }
            }
            audioSource.PlayOneShot(ShootSound, 1F);
            Ammo--;
        }
        else
        {
            StartCoroutine(Reload());
        }

    }
    public override void DamageFormula()
    {
        Damage = BaseDamage + (2 * (WeaponLVL - 1));
    }
}
