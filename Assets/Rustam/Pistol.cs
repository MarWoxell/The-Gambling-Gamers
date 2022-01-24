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
        base.Fire();
    }
    public override void DamageFormula()
    {
        base.DamageFormula();
    }
}
