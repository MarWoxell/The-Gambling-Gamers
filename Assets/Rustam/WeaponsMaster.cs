using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsMaster : MonoBehaviour
{
    public Pistol pistol;
    public AR ak;
    public Shotgun shotgun;


    // Start is called before the first frame update
    void Start()
    { //Ser till att man börjar med smgn

        PistolActive();
    }

    // Update is called once per frame
    void Update()
    { //När man trycker på e så cyclas listan av vapen
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PistolActive();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && ak.WeaponLVL > 0)
        {
            AKActive();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && shotgun.WeaponLVL > 0)
        {
            ShotgunActive();
        }
    }
   void PistolActive()
    {
        pistol.WeaponActive = true;
        ak.WeaponActive = false;
        shotgun.WeaponActive = false;
        print("1");
    }
    void AKActive()
    {
        pistol.WeaponActive = false;
        ak.WeaponActive = true;
        shotgun.WeaponActive = false;
        print("2");
    }
    void ShotgunActive()
    {
            pistol.WeaponActive = false;
            ak.WeaponActive = false;
            shotgun.WeaponActive = true;
            print("3");
    }
}