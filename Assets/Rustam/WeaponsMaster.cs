using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rustam
public class WeaponsMaster : MonoBehaviour
{
    public Pistol pistol;
    public AR ak;
    public Shotgun shotgun;

    public GameUI gameUi;
    public Transform TrailStart;

    // Start is called before the first frame update
    void Start()
    { //Ser till att man börjar med Pistolen

        PistolActive();
    }

    // Update is called once per frame
    void Update()
    { //Byter till ett vapen baserat på vilken knapp du trycker på
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PistolActive();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && SaveObject.instance.arLv > 0)
        {
            AKActive();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && SaveObject.instance.shotgunLv > 0)
        {
            ShotgunActive();
        }
    }
   void PistolActive()
    {
        //Deaktiverar alla andra vapen, ändrar spriten, ändrar ammo promten och positionen för vart bullet trailen kommer från
        pistol.WeaponActive = true;
        ak.WeaponActive = false;
        shotgun.WeaponActive = false;
        pistol.WeaponRenderer.sprite = pistol.IdleSprite;
        print("1");
        gameUi.PistolText();
        TrailStart.transform.localPosition = new Vector3 (0.1f, 0.5f, 0.1f);
    }
    void AKActive()
    {
        //Samma sak som pistolactive
        pistol.WeaponActive = false;
        ak.WeaponActive = true;
        shotgun.WeaponActive = false;
        ak.WeaponRenderer.sprite = ak.IdleSprite;
        print("2");
        gameUi.ARText();
        TrailStart.transform.localPosition = new Vector3(-0.015f, 0.5f, 0.1f);
    }
    void ShotgunActive()
    {
        //Samma sak som pistolactive
        pistol.WeaponActive = false;
        ak.WeaponActive = false;
        shotgun.WeaponActive = true;
        shotgun.WeaponRenderer.sprite = shotgun.IdleSprite;
        print("3");
        gameUi.ShotgunText();
        TrailStart.transform.localPosition = new Vector3(0.075f, 0.5f, 0.3f);
    }
}