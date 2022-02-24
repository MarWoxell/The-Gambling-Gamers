using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Oscar
public class watchAD : hpsliderscript
{// variblar för att kolla på våran add skelva vidio playern ad bolen så man inte kan kolla flera gånger i samma play trow och sedan tiden för ad
    public GameObject ad;
    public bool abeltowatch;
    public float adtime = 30;
    private void Start()
    {//säter aden diactive
        ad.SetActive(false);
        abeltowatch = (true);
    }
    public void playAD()
    {// på konapen så kolla förs ifal det är ens möjligt att kolla på aden och sedan så 
        if (abeltowatch = (true))
        {//startar aden startar också en timer och sedan säter timmern för hur lång den är på
            ad.SetActive(true);
            abeltowatch = false;
            adtime -= Time.deltaTime;

            if (adtime <= 0)
            {//säter tillback till liv playern och tar ner death overlyn
                ad.SetActive(false);
                heal(100);
                isDead = false;
                Time.timeScale = 1;
                deadoverlay.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;

                print("whatched ad");
            }
        }
        else
        {//kan ej kolla

            print("cant watch");
        }


    }
    

   
}
