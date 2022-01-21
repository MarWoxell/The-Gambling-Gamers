using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon
{
    public int Shellcount;
    public int MaxDev;

    void Start()
    {

        Ammo = MagSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (WeaponLVL > 0 && WeaponActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("Firing");
                Fire();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }
        DamageFormula();
    }
    public override void Fire()
    {
        for (int i = 1; i <= Shellcount; i++)
        {
            Vector3 ForwardVector = Vector3.forward;
            float Deviation = Random.Range(0f, MaxDev);
            ForwardVector = Quaternion.AngleAxis(Deviation, Vector3.up) * ForwardVector;
            ForwardVector = Cam.transform.rotation * ForwardVector;


            audioSource.PlayOneShot(ShootSound, 1F);
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, ForwardVector, out hit, Range))
            {
                if (Ammo > 0)
                {
                    StartCoroutine(Animation());
                    audioSource.PlayOneShot(ReloadSound);
                    TrailRenderer Trail = Instantiate(BulletTrail, TrailStart.transform.position, Quaternion.Euler(Cam.transform.forward));
                    StartCoroutine(SpawnTrail(Trail, hit));

                    EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(Damage);
                    }
                    //Ammo--;
                }
                else
                {
                    StartCoroutine(Reload());
                }
            }
        }
        Ammo--;
    }
    public override void DamageFormula()
    {
        Damage = BaseDamage + (2 * (WeaponLVL - 1));
    }
}
