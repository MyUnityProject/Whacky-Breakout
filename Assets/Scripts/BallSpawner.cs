using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    Timer BallSpawnTimer;
    Timer BallSpeedUp;
    bool IsSpeed = false;


    [SerializeField]
    GameObject ball;

    Vector2 UpperLeftCorner;
    Vector2 LowerRightCorner;
	// Use this for initialization

	void Start ()
    {
        BoxCollider2D boxCollider2D = ball.GetComponent<BoxCollider2D>();
        Vector2 boxSize = boxCollider2D.size;
        UpperLeftCorner = new Vector2((0 - boxSize.x) / 2, (0 - boxSize.y) / 2);
        LowerRightCorner = new Vector2((0 + boxSize.x) / 2, (0 + boxSize.y) / 2);
        Instantiate(ball, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        BallSpawnTimer = gameObject.AddComponent<Timer>();
        BallSpawnTimer.TimerDuration = Random.Range(ConfigurationUtils.MinBallSpawnDuration, ConfigurationUtils.MaxBallSpawnDuration);
        BallSpawnTimer.Run();
        BallSpeedUp = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedListener(SpeedUp);
        EventManager.AddSpawnBallListener(spawnBall);

    }
	
	// Update is called once per frame
	void Update ()
    {
        
		if(BallSpawnTimer.Finished)
        {
            if (Physics2D.OverlapArea(UpperLeftCorner, LowerRightCorner) == null)
            {
                spawnBall();
            }
            else
            {
                BallSpawnTimer.TimerDuration = 1;
                BallSpawnTimer.Run();
            }
            BallSpawnTimer.TimerDuration = Random.Range(ConfigurationUtils.MinBallSpawnDuration, ConfigurationUtils.MaxBallSpawnDuration);
            BallSpawnTimer.Run();
        }

        if (BallSpeedUp.Finished)
            IsSpeed = false;
	}


    void SpeedUp(float multiplier)
    {
        if (BallSpeedUp.Running)
            BallSpeedUp.IncreaseDuration(multiplier);
        else
        {
            BallSpeedUp.TimerDuration = multiplier;
            BallSpeedUp.Run();
            IsSpeed = true;
        }
    }

    void spawnBall()
    { 
        GameObject tempBall = Instantiate(ball, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        if (IsSpeed == true)
        {
            tempBall.GetComponent<Ball>().speedMagnifier = 2;
            tempBall.GetComponent<Ball>().SpeedUp(ConfigurationUtils.SpeedDuration);
        }
    }


}
