using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hpsliderscript : MonoBehaviour
{// varibalar f�r skelva slidern och sedan f�r death overlyn
    public int playerhp;

    public Text ScoreText;
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public GameObject oldscoretext;

    public GameObject deadoverlay;
    public GameObject tranformscore;

    public GameObject HitParticleEffect;
    public Color HitParticleColor;

   
    private void Start()
    {// i starten s� s� kallar jag p� scriptensen soundplayer och screnshake sedan s� steter jag death overlyn till false och till sistet s� st�er jag max hp til 100
      
        playerhp = 100;
        SetMaxHealth(playerhp);
        deadoverlay.SetActive(false);
    }
    public void SetMaxHealth(int health)
    {// i b�rjan ster gradienten s� den passar och sedan fixtar till slidern till en valu av 100
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {// n�r du tar damage  och ster slidern till r�tt f�rg och m�ngd
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            heal(100);
        }
         if (playerhp <= 0)
        {
          

        }
    }

    public void takedamage(int damage)
    {// n�r du tar damge s� ster vi hpen till det och sedan skikar till backa
        playerhp -= damage;
        

        SetHealth(playerhp);
    }

    public void heal(int heal)
    {// ifall man ville ha att man kunde heala
        playerhp += heal;
        SetHealth(playerhp);
    }

    public void relodscen()
    {// n�r du d�r s� fins det en knap f�r n�r man vil k�r om 

        
    }
    public void menu()
    {// g�r till back atill menu

       
    }

}
