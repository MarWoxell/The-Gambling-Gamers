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

        AKActive();
    }

    // Update is called once per frame
    void Update()
    { //När man trycker på e så cyclas listan av vapen
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PistolActive();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AKActive();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShotgunActive();
        }
    }
   void PistolActive()
    {
        pistol.enabled = true;
        ak.enabled = false;
        shotgun.enabled = false;
        print("1");
    }
    void AKActive()
    {
        pistol.enabled = false;
        ak.enabled = true;
        shotgun.enabled = false;
        print("2");
    }
    void ShotgunActive()
    {
            pistol.enabled = false;
            ak.enabled = false;
            shotgun.enabled = true;
            print("3");
    }
}