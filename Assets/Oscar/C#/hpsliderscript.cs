using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hpsliderscript : MonoBehaviour
{// varibalar för skelva slidern och sedan för death overlyn
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
    {// i starten så så kallar jag på scriptensen soundplayer och screnshake sedan så steter jag death overlyn till false och till sistet så stäer jag max hp til 100
      
        playerhp = 100;
        SetMaxHealth(playerhp);
        deadoverlay.SetActive(false);
    }
    public void SetMaxHealth(int health)
    {// i början ster gradienten så den passar och sedan fixtar till slidern till en valu av 100
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {// när du tar damage  och ster slidern till rätt färg och mängd
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
    {// när du tar damge så ster vi hpen till det och sedan skikar till backa
        playerhp -= damage;
        

        SetHealth(playerhp);
    }

    public void heal(int heal)
    {// ifall man ville ha att man kunde heala
        playerhp += heal;
        SetHealth(playerhp);
    }

    public void relodscen()
    {// när du dör så fins det en knap för när man vil kör om 

        
    }
    public void menu()
    {// går till back atill menu

       
    }

}
