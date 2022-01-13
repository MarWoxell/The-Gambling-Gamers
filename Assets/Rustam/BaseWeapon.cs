using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : Enemy
{
    public AudioClip ShootSound;
    public AudioSource audioSource;

    public int Damage;
    public float Range;
    public Camera Cam;
    public int MagSize;
    public int Ammo;
    public float Reloadtime;


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
    IEnumerator Reload()
    {
        yield return null;
        yield return new WaitForSeconds(Reloadtime);
        Ammo = MagSize;
    }
}
