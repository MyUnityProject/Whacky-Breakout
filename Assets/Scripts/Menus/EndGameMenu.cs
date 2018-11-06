using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour {

    int score = 0;
    Text finalScore;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        Hudscript hudscript = GameObject.FindGameObjectWithTag("HUD").GetComponent<Hudscript>();
        score = hudscript.GetScore();
        finalScore = GameObject.FindGameObjectWithTag("FinalScore").GetComponent<Text>();
        finalScore.text = "SCORE : " + score;

	}
	
    public void MenuOnPressedHandler()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        SceneManager.LoadScene("Main Menu");

    }

}
