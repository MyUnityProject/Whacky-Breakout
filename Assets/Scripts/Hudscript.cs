using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Hudscript : MonoBehaviour {

    // Use this for initialization
    static string score = "Score : ";
    static string balls = "Balls : ";
    int points = 0;
    int remainingBalls = 0;
    Text ScoreText;
    Text BallText;

    //Initalize UnityEvents


	void Start () {

        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        BallText = GameObject.FindGameObjectWithTag("BallText").GetComponent<Text>();
        remainingBalls = ConfigurationUtils.MaxBlockNumber;
        EventManager.AddPointListener(AddPoints);
        EventManager.AddBallListener(RemoveBalls);
    }
	
	// Update is called once per frame
	void Update () {
        if(ScoreText != null)
            ScoreText.text = score + points;
        if(BallText != null)
            BallText.text = balls + remainingBalls;
	}

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public void RemoveBalls(int ball)
    {
        remainingBalls -= ball;
        if (remainingBalls < 0)
            MenuManager.GoToMenu(MenuName.EndGameMenu);
    }

    public int GetScore()
    { return points; }
}
