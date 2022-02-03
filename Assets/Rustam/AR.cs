using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : BaseWeapon
{
    private float ActualFireRate;
    // Start is called before the first frame update
    void Start()
    {

        Ammo = MagSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveObject.instance.arLv > 0 && WeaponActive == true && IsReloading == false)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (StopShoot == false)
                {
                    StartCoroutine(FirePause());
                }
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
        base.Fire();
        //0.25 Sekunder senare slutar cooldownen
        yield return new WaitForSeconds(0.15f);
        StopShoot = false;
    }
    public override void DamageFormula()
    {
        Damage = BaseDamage + (2 * (SaveObject.instance.arLv - 1));
        MagSize = 30 + 5 * (SaveObject.instance.arLv - 1 );
    }
    public override IEnumerator Animation()
    {
        yield return null;
        WeaponRenderer.sprite = FireSprite;
        yield return new WaitForSeconds(0.5f);
        if (WeaponManager.ak.WeaponActive == true)
        {
            WeaponRenderer.sprite = IdleSprite;
        }
    }
}
