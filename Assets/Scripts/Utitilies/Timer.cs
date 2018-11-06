using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    #region fields


    float timerDuration = 10;
    float elapsedSeconds = 0;

    bool isRunning = false;
    bool isStarted = false;


    #endregion

    #region properties


    //Set the timer Duration
    public float TimerDuration
    {
        set {
                if (!isRunning)
                {
                timerDuration = value;
                }
        }
    }

    //Check if timer is running
    public bool Running
    {
        get { return isRunning; }
    }

    //Check if timer is Finished
    public bool Finished
    {
        get { return isStarted && !isRunning; }
    }


    #endregion

    #region functions


    public void Run()
    {
        
        if(timerDuration > 0)
        {
            isRunning = true;
            isStarted = true;
            elapsedSeconds = 0;
        }
    }

	void Update () {
        
		if(isRunning)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds > timerDuration)
                isRunning = false;
        }
	}

    public void IncreaseDuration(float IncreaseTime)
    {
        timerDuration += IncreaseTime;
    }

    #endregion
}
