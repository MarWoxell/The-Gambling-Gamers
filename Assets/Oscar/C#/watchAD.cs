using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Oscar
public class watchAD : hpsliderscript
{// variblar f�r att kolla p� v�ran add skelva vidio playern ad bolen s� man inte kan kolla flera g�nger i samma play trow och sedan tiden f�r ad
    public GameObject ad;
    public bool abeltowatch;
    public float adtime = 30;
    private void Start()
    {//s�ter aden diactive
        ad.SetActive(false);
        abeltowatch = (true);
    }
    public void playAD()
    {// p� konapen s� kolla f�rs ifal det �r ens m�jligt att kolla p� aden och sedan s� 
        if (abeltowatch = (true))
        {//startar aden startar ocks� en timer och sedan s�ter timmern f�r hur l�ng den �r p�
            ad.SetActive(true);
            abeltowatch = false;
            adtime -= Time.deltaTime;

            if (adtime <= 0)
            {//s�ter tillback till liv playern och tar ner death overlyn
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
        {
            print("cant watch");
        }


    }
    

   
}