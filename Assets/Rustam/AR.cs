using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : BaseWeapon
{

    private bool StopShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        Ammo = MagSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (StopShoot == false)
            {
                StartCoroutine(FirePause());
            }
        }
    }
    public override void Fire()
    {
        
    }

    IEnumerator FirePause()
    {
        //Cooldownen startas
        StopShoot = true;
        yield return null;
        base.Fire();
        //0.25 Sekunder senare slutar cooldownen
        yield return new WaitForSeconds(0.33f);
        StopShoot = false;
    }
}
