using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseWeapon
{
    //Rustam
    //?rver fr?n Baseweapon
    // Start is called before the first frame update
    void Start()
    {


        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Cam.transform.position, Cam.transform.forward * Range);
        if (SaveObject.instance.pistolLv > 0 && WeaponActive == true && IsReloading == false && StopShoot == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("Firing");
                StartCoroutine(FirePause());
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
                print("r");
            }
        }
        DamageFormula();
    }
   /* public override void Fire()
    {
        base.Fire();
    }*/
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

    public override IEnumerator Animation()
    {
        yield return null;
        WeaponRenderer.sprite = FireSprite;
        yield return new WaitForSeconds(0.5f);
        if(WeaponManager.pistol.WeaponActive == true)
        {
            WeaponRenderer.sprite = IdleSprite;
            print("is pistol rn");
        }    
        else
        {
            print("not pistol rn");
        }
    }
}
