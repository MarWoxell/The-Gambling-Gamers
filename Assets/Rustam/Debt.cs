using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rustam
public class Debt : MonoBehaviour, Interactable
{
    //Ett simeplt skript som checkar för om du har tillräckligt med pengar för att betala av din skuld, och ifall du gör sparar den, drar av pengarna och spelar storyn
    public int DebtAmount;
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
        if (SaveObject.instance.money >= DebtAmount)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;
            timeSave.Save();
            DebtAmount = 0;
            SaveObject.instance.money -= DebtAmount;
            GetComponent<TriggerStory>().StoryTrigger();
            
        }
        SaveObject.instance.money = 0;
    }
}
