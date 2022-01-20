using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debt : MonoBehaviour, Interactable
{
    public int DebtAmount = 50000;
    public TimeSave timeSave;


    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (DebtAmount <= 0)
        {
            print("You've won the game");
        }
    }

    public void Thing()
    {
        if (Player.money >= 50000)
        {
            DebtAmount = 0;
            Player.money -= 50000;
            timeSave.Save();
        }
        Player.money = 0;
    }
}
