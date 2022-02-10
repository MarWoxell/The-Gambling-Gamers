using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oscar
public class Gambling : MonoBehaviour, Interactable
{
   
    public void Thing()
    {//först så skapar jag rustams interactabole och gör funktionen thing som han har skapat som desn så säter jag perameten att man måste ha 1000 mont för att använda gacha
        if (SaveObject.instance.money >= 1000)
        {
            monygacha();
        }
    }

    public void monygacha()
    {// när vi börjar så tar jag bort 1000 sedan så skapar jag en radom som bestämer ifall du vinner eller inte
        SaveObject.instance.money -= 1000;

        int rangmony = Random.Range(1, 4);
        
        if (rangmony >= 2)
        {//ifall den är 2 eller mindre så viner du och då skapas en till random som ifalld u akn vinna mycket med pengar 20000 för att vara exakt
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
