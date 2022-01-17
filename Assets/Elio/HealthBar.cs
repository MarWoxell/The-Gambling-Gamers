using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider playerHealthBar;
    public void setMaxHealth(int health)
    {
        playerHealthBar.maxValue = health;
        playerHealthBar.value = health;
    }

    public void ChangeHealth(int health)
    {
        playerHealthBar.value = health;
    }
}
