using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
   /* // sätt in saker i editor (sakerna där datan finns)
    public TimeSave time;
    public AR ar;
    public Shotgun sg;
    public Pistol handgun;
    public Player cash;
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData");
        SaveMoneyAndGuns saveMoneyAndGuns = new SaveMoneyAndGuns(time, ar, sg, handgun, cash);
        
        bf.Serialize(file, saveMoneyAndGuns);
        file.Close();
        print("Game is saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData"))
        {
            print("11");
            BinaryFormatter bf = new BinaryFormatter();
            print("12");
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData", FileMode.Open);
            print("13");
            SaveMoneyAndGuns save = (SaveMoneyAndGuns)bf.Deserialize(file);
            print("14");
            file.Close();
            
            print("Game data loaded!");
        }
        else
        {
            print("There is no save data!");
        }
    }*/

}
