using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oscar
public class Gambling : MonoBehaviour, Interactable
{
   
    public void Thing()
    {//f�rst s� skapar jag rustams interactabole och g�r funktionen thing som han har skapat som desn s� s�ter jag perameten att man m�ste ha 1000 mont f�r att anv�nda gacha
        if (SaveObject.instance.money >= 1000)
        {
            monygacha();
        }
    }

    public void monygacha()
    {// n�r vi b�rjar s� tar jag bort 1000 sedan s� skapar jag en radom som best�mer ifall du vinner eller inte
        SaveObject.instance.money -= 1000;

        int rangmony = Random.Range(1, 4);
        
        if (rangmony >= 2)
        {//ifall den �r 2 eller mindre s� viner du och d� skapas en till random som ifalld u akn vinna mycket med pengar 20000 f�r att vara exakt
            int dubble = Random.Range(1, 500);
            
            if(dubble == 1)
            {
                print("ha");
                SaveObject.instance.money += 20000;
                // ger pengarna ifall man vinner jacpoten
            }
            else
            {
                SaveObject.instance.money += 2250;
                // ger normala vinsten
                print("yes");
            }
        }
        
    }
}
