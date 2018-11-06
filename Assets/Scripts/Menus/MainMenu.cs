using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void HandlePlayButtonClick()
    {
        SceneManager.LoadScene("Scene0");
    }

    public void HandleHelpButtonClick()
    { 
        SceneManager.LoadScene("Help Menu");
    }

    public void HandleQuitButtonClick()
    {
        Application.Quit();
    }
}
