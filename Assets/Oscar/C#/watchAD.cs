using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Oscar
public class watchAD : MonoBehaviour
{// variblar f�r att kolla p� v�ran add skelva vidio playern ad bolen s� man inte kan kolla flera g�nger i samma play trow och sedan tiden f�r ad
    public GameObject ad;
    public hpsliderscript hpSlider;
    public bool abeltowatch;
    public float adtime = 30;
    private void Start()
    {//s�ter aden diactive
        ad.SetActive(false);
        abeltowatch = (true);
    }
    public void Update()
    {
       
        if(abeltowatch == (false))
        {
            Time.timeScale = 1;
            adtime -= Time.deltaTime;
            
            print(adtime);
            
            if (adtime <= 0)
            {//s�ter tillback till liv playern och tar ner death overlyn
                print("heald");
                ad.SetActive(false);

               

                hpSlider.deadoverlay.SetActive(false);

                hpSlider.heal(100);



                Cursor.lockState = CursorLockMode.Locked;

                print("whatched ad");
            }
        }
    }
    public void playAD()
    {// p� konapen s� kolla f�rs ifal det �r ens m�jligt att kolla p� aden och sedan s� 
        if (abeltowatch == (true))
        {//startar aden startar ocks� en timer och sedan s�ter timmern f�r hur l�ng den �r p�
            abeltowatch = false;
            ad.SetActive(true);
           
        
            
           
        }
        else
        {//kan ej kolla

            print("cant watch");
        }


    }
    

   
}
