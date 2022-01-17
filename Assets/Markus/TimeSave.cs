using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSave : MonoBehaviour
{
    // Skrivet av Markus
    public float time;

    public float betterTime;

    public Text timer;

    public Text bestScore;


    void Start()
    {
        betterTime = PlayerPrefs.GetFloat("time", time);
        bestScore.text = "Your Best Time " + betterTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        timer.text = "Time " + time.ToString("F2");
    }

    // Sparar tiden och kollar ifall man är snabbare och ifall det är ens första run
    public void Save()
    {
        if (time < betterTime)
        {
            PlayerPrefs.SetFloat("time", time);
        }
        else if (betterTime == 0f)
        {
            PlayerPrefs.SetFloat("time", time);
        }

        SceneManager.LoadScene("MainMenu");
    }

    // Resetar tiden i menyn
    public void resetTime()
    {
        time = 0;
        PlayerPrefs.SetFloat("time", 0);
        bestScore.text = "Your Best Time " + time;
    }
}
