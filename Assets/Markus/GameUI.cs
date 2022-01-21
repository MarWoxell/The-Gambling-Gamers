using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text money;
    public Text gun;
    public Text ammo;

    public Pistol pistol;
    public AR aR;
    public Shotgun shotgun;
    public Player player;

    public int gunNumber;
    public void Start()
    {
        gunNumber = 0;
    }

    public void Update()
    {
        money.text = "$" + Player.money.ToString();

        if (gunNumber == 0)
        {
            ammo.text = pistol.Ammo.ToString() + "/" + pistol.MagSize.ToString();
        }
        if (gunNumber == 1)
        {
            ammo.text = aR.Ammo.ToString() + "/" + aR.MagSize.ToString();
        }
        if (gunNumber == 2)
        {
            ammo.text = shotgun.Ammo.ToString() + "/" + shotgun.MagSize.ToString();
        }

    } 
    public void ShotgunText()
    {
        gun.text = ("Shotgun");
        print("shotgun");
        gunNumber = 2;
    }
    public void ARText()
    {
        gun.text = ("AK");
        print("Ak");
        gunNumber = 1;
    }
    public void PistolText()
    {
        gun.text = ("Pistol");
        print("Pistol");
        gunNumber = 0;
    }

}
