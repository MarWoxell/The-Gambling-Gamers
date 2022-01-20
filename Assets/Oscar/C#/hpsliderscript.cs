using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//oscar
public class hpsliderscript : MonoBehaviour
{// varibalar f�r skelva slidern och sedan f�r death overlyn
    public int playerhp;
    public static bool isDead;

    public Text ScoreText;
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public GameObject deadoverlay;


   
    private void Start()
    { 
        
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
          //v  heal(100);
        }
         if (playerhp <= 0)
        {
            isDead = true;
            Time.timeScale = 0;
            deadoverlay.SetActive(true); 
            Cursor.lockState = CursorLockMode.None;
            //ScoreText.text = "Score: " + GetComponent<timeskriptet>().score;


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


        SceneManager.LoadScene(2);

    }
    public void menu()
    {// g�r till back atill menu


        SceneManager.LoadScene(0);

    }

}
