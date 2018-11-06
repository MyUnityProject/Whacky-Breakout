using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch(name)
        {
            case MenuName.MainMenu:
                SceneManager.LoadScene("Main Menu");
                break;

            case MenuName.PauseMenu:
                Object.Instantiate(Resources.Load("Pause Menu"));
                break;
            case MenuName.HelpMenu:
                SceneManager.LoadScene("Help Menu");
                break;
            case MenuName.EndGameMenu:
                Object.Instantiate(Resources.Load("EndGame Menu"));
                break;

        }
    }
}
