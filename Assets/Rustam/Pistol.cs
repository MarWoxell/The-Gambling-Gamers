using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseWeapon
{

    // Start is called before the first frame update
    void Start()
    {


        Ammo = MagSize;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Cam.transform.position, Cam.transform.forward * Range);
        if (WeaponLVL > 0 && WeaponActive == true && IsReloading == false && StopShoot == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("Firing");
                StartCoroutine(FirePause());
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
        base.Fire();
    }
    IEnumerator FirePause()
    {
        print("Stopshotting");
        //Cooldownen startas
        StopShoot = true;
        yield return null;
        base.Fire();
        //0.25 Sekunder senare slutar cooldownen
        yield return new WaitForSeconds(0.25f);
        StopShoot = false;
    }
    public override void DamageFormula()
    {
        base.DamageFormula();
    }
}
