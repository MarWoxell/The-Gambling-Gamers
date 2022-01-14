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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("Firing");
            Fire();
        }
        
    }
    public override void Fire()
    {
        base.Fire();
    }
}
