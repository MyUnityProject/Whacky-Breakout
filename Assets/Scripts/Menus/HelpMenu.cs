﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour {

    public void HandleBackButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
