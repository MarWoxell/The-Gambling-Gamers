using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour, Interactable
{
    public Object[] Winnable;
    public Pistol pistol;
    public AR ak;
    public Shotgun shotgun;

    public AudioSource PlayerAudio;
    public AudioClip GamblingSound;

    public SpriteRenderer renderer1;
    public SpriteRenderer renderer2;
    public SpriteRenderer renderer3;

    public Sprite PistolSprite;
    public Sprite AKSprite;
    public Sprite ShotgunSprite;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Thing()
    {
        if (SaveObject.instance.money >= 1000)
        {
            //L?ter dig gambla om du har 1000 pengar
            Gamble();
        }
    }

    void Gamble()
    {
        SaveObject.instance.money -= 1000;
        PlayerAudio.PlayOneShot(GamblingSound);
        int Result = Random.Range(1, 4);
        print(Result);
        //Skriptet k?r en random.range fr?n 1 till 3, och h?jer din pistol level om du f?r 1, ak level om du f?r 2 osv
        if(Result == 1)
        {
            SaveObject.instance.pistolLv++;
            //pistol.WeaponLVL++;
            StartCoroutine(Icon(PistolSprite));
        }
        if (Result == 2)
        {
            SaveObject.instance.arLv++;
            //ak.WeaponLVL++;
            StartCoroutine(Icon(AKSprite));
        }
        if (Result == 3)
        {
            SaveObject.instance.shotgunLv++;
            //shotgun.WeaponLVL++;
            StartCoroutine(Icon(ShotgunSprite));
        }

    }
    public IEnumerator Icon(Sprite sprit)
    {
        //G?r korresponderade sprite synlig p? automaten i tre sekunder
        yield return null;
        renderer1.sprite = sprit;
        renderer2.sprite = sprit;
        renderer3.sprite = sprit;
        yield return new WaitForSeconds(3f);
        renderer1.sprite = null;
        renderer2.sprite = null;
        renderer3.sprite = null;
    }
}
