using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon
{
    public int Shellcount;
    public float MaxDev;

    void Start()
    {

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //Låter dig vara skjuta om du har shotgunen och inget annat interruptar
        if (SaveObject.instance.shotgunLv > 0 && WeaponActive == true && IsReloading == false && StopShoot == false)
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
        //1 Sekunder senare slutar cooldownen
        yield return new WaitForSeconds(1f);
        StopShoot = false;
    }
    public override void Fire()
    {
        //Allt det här är basically samma sak som i baseweapon, men med random deviation på skotten
        print("Firing");
        if(Ammo > 0)
        {
            for (int i = 1; i <= Shellcount; i++)
            {

                //Skapar en offset och lägger den på centrala kameran
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
    public override IEnumerator Animation()
    {
        yield return null;
        WeaponRenderer.sprite = FireSprite;
        yield return new WaitForSeconds(0.5f);
        if (WeaponManager.shotgun.WeaponActive == true)
        {
            WeaponRenderer.sprite = IdleSprite;
        }
    }
    public override void DamageFormula()
    {
        Damage = BaseDamage + (2 * (SaveObject.instance.shotgunLv - 1));
    }
}
