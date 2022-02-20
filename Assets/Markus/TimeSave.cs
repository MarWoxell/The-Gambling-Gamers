using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSave : MonoBehaviour
{
    // Skrivet av Markus

    public float betterTime;

    public Text timer;

    public Text bestScore;

    public SaveData test;


    void Start()
    {
        betterTime = PlayerPrefs.GetFloat("time", SaveObject.instance.time);
        bestScore.text = "Your Best Time " + betterTime.ToString("F2");
    }

    private void Awake()
    {
        betterTime = PlayerPrefs.GetFloat("time", SaveObject.instance.time);
        print("it not the thing");
        bestScore.text = "Your Best Time " + betterTime.ToString("F2");
        print("it do the thing");
    }


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Markus"))
        {
            SaveObject.instance.time += Time.deltaTime;
        }
        

        timer.text = "Time " + SaveObject.instance.time.ToString("F2");
    }

    // Sparar tiden och kollar ifall man är snabbare och ifall det är ens första run
    public void Save()
    {
        if (SaveObject.instance.time < betterTime)
        {
            PlayerPrefs.SetFloat("time", SaveObject.instance.time);
            print("time does studd");
        }
        else if (betterTime == 0f)
        {
            PlayerPrefs.SetFloat("time", SaveObject.instance.time);
            print("saves times");
        }

        SceneManager.LoadScene("MainMenu");
    }

    // Resetar data i menyn
    public void resetTime()
    {

        SaveObject.instance.pistolLv = 1;
        SaveObject.instance.arLv = 0;
        SaveObject.instance.shotgunLv = 0;
        SaveObject.instance.money = 0;
        SaveObject.instance.time = 0;

        PlayerPrefs.SetFloat("time", 0);
        bestScore.text = "Your Best Time " + SaveObject.instance.time;
        print("happening");

        test.SavePlayer();


    }
}
