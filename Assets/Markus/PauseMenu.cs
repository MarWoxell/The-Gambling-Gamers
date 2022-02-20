using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Skrivet av Markus

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenu;

    public SaveData save;
    

    private void Start()
    {
        print("loded mabye");
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Kollar ifall spelet är pausat och ifall man lever
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && hpsliderscript.isDead == false)
        {
            if (paused == false)
            {
               
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                paused = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                paused = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    // De fyra funktioner är knappar som finns i paus menyn
    public void Resume()
    {
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void game()
    {
        
        SceneManager.LoadScene("ee");
    }

    public void Gacha()
    {
        
        SceneManager.LoadScene("Oscar");
    }
    public void Quit()
    {
        save.SavePlayer();
        SceneManager.LoadScene("Markus");
    }

}
