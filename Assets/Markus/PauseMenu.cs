using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    public GameObject pauseMenu;

    private void Start()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                //set active true

                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                paused = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                // set active false
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                paused = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Gacha()
    {
        SceneManager.LoadScene("Oscar");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Markus");
    }

}
