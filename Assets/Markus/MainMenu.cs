using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Begin()
    {
        SceneManager.LoadScene("Markus2");
    }

    public void Quit()
    {
        Application.Quit();
        // avslutar spelet
    }

    

}
