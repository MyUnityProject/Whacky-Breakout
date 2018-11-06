using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
    public void OnResumeButtionClick()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void OnQuitButtionClick()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        SceneManager.LoadScene("Main Menu");
    }
}
