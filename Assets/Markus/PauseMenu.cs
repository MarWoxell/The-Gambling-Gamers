using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenu;
    

    private void Start()
    {
        GetComponent<SaveManager>().LoadGame();
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
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
    public void game()
    {
        GetComponent<SaveManager>().SaveGame();
        SceneManager.LoadScene("ee");
    }

    public void Gacha()
    {
        GetComponent<SaveManager>().SaveGame();
        SceneManager.LoadScene("Oscar");
    }
    public void Quit()
    {
        GetComponent<SaveManager>().SaveGame();
        SceneManager.LoadScene("Markus");
    }

}
