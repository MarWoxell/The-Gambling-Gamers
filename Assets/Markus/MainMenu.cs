using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Skrivet av Markus
public class MainMenu : MonoBehaviour
{
    public SaveData save;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }

    public void Begin()
    {
        SceneManager.LoadScene("ee");
    }

    public void Quit()
    {
        save.SavePlayer();
        Application.Quit();
        // avslutar spelet
    }

    

}
