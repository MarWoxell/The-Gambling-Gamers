using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : BaseWeapon
{

    private bool StopShoot = false;
    private float ActualFireRate;
    // Start is called before the first frame update
    void Start()
    {

        Ammo = MagSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (WeaponLVL > 0 && WeaponActive == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (StopShoot == false)
                {
                    StartCoroutine(FirePause());
                }
            }
        }
        DamageFormula();
    }

    IEnumerator FirePause()
    {
        //Cooldownen startas
        StopShoot = true;
        yield return null;
        base.Fire();
        //0.25 Sekunder senare slutar cooldownen
        yield return new WaitForSeconds(0.15f);
        StopShoot = false;
    }
    public override void DamageFormula()
    {
        Damage = BaseDamage + (2 * (WeaponLVL - 1));
        MagSize = 30 + 5 * (WeaponLVL - 1 );
    }
}
