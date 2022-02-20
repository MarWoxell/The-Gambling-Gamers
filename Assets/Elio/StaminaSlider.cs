using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script by Elio with the help of Oscars hpsliderscript
public class StaminaSlider : MonoBehaviour
{
    public float stamina;
    public bool outOfStamina, noDoubles;

    public Slider slider;
    private void Start()
    {
        noDoubles = true;
        stamina = 100f;
        SetMaxStamina(stamina);
    }

    public IEnumerator RegainStamina()
    {//Made by me - Elio
        noDoubles = false;
        yield return new WaitForSeconds(2.75f);
        outOfStamina = false;
        noDoubles = true;
    }
    public void SetMaxStamina(float stamina)
    {// i början ster gradienten så den passar och sedan fixtar till slidern till en valu av 100 - Oscar
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    public void SetStamina(float stamina)
    {// när du tar damage  och ster slidern till rätt färg och mängd -Oscar
        slider.value = stamina;
    }

    private void Update()
    {
        if (stamina > 100)
        {
            stamina = 100;
        }
        if (stamina <= 0)
        {// säter boolen som är att du är död till true sedan så säter på deat overlayensedan tar fram cursorn - Oscar
            outOfStamina = true;
        }
        if (outOfStamina == true && noDoubles == true)
        {
            //If you're out of stamina it waits for stamina to go up again before you can sprint again - Elio
            StartCoroutine(RegainStamina());
        }
    }
}
