using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Skivet av Markus

public class SaveData : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadGame();
        }
    }



    // Converterar data till binär
    public void SavePlayer()
    {
        BinaryFormatter formatter = GetBinaryFormatter();


        FileStream file = File.Create(Application.persistentDataPath + "Markus.W");
        SaveMoneyAndGuns save = new SaveMoneyAndGuns();

        save.money = SaveObject.instance.money;
        save.arLV = SaveObject.instance.arLv;
        save.pistol = SaveObject.instance.pistolLv;
        save.shotgun = SaveObject.instance.shotgunLv;
        save.time = SaveObject.instance.time;

        formatter.Serialize(file, save);
        file.Close();
    }

    // converterar binär till data
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath +"Markus.W"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "Markus.W", FileMode.Open);
            SaveMoneyAndGuns save = (SaveMoneyAndGuns)bf.Deserialize(file);
            file.Close();
            SaveObject.instance.money = save.money;
            SaveObject.instance.arLv = save.arLV;
            SaveObject.instance.pistolLv = save.pistol;
            SaveObject.instance.shotgunLv = save.shotgun;
            SaveObject.instance.time = save.time;

            print("Game data loaded!");
        }
        else
        {
            print("There is no save data!");
        }
    }


    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }
}
