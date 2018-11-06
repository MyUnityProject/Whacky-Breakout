using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour {

    Timer BallDestroy;
    Timer BallWait;
    Timer BallSpeedUp;
    Vector2 dir;
    bool StartBall = true;
    bool TimeOut = false;
    bool IsSpeed = false;
    public float speedMagnifier = 1;

    IntEvent reduceBall = new IntEvent();
    UnityEvent spawnBall = new UnityEvent();

    // Use this for initialization
    void Start () {

        dir = new Vector2(0f, -1f);
        BallWait = gameObject.AddComponent<Timer>();
        BallDestroy = gameObject.AddComponent<Timer>();
        
        BallWait.TimerDuration = 1;
        BallDestroy.TimerDuration = ConfigurationUtils.BallLifetime;
        BallWait.Run();
        EventManager.AddSpeedListener(SpeedUp);
        EventManager.AddBallInvoker(this);
        EventManager.AddSpawnBallInvoker(this);
        
	}
	
	// Update is called once per frame
	void Update () {
        
		if(BallWait.Finished && StartBall)
        {
            
            GetComponent<Rigidbody2D>().AddForce(dir * ConfigurationUtils.BallImpulseForce * speedMagnifier, ForceMode2D.Impulse);
            BallDestroy.Run();
            StartBall = false;
        }

        if (BallDestroy.Finished)
        {
            TimeOut = true;
            AudioManager.Play(AudioClipName.BallFall);
            spawnBall.Invoke();
            Destroy(gameObject);
        }

        if(BallSpeedUp != null)
            if(BallSpeedUp.Finished && IsSpeed)
            {
                GetComponent<Rigidbody2D>().velocity /= 2;
                IsSpeed = false;
            }
	}

    
    public void SetDirection(Vector2 direction)
    {
        Vector2 CurrentVelocity = GetComponent<Rigidbody2D>().velocity;
        Vector2 NewVelocity = direction * CurrentVelocity.magnitude;
        GetComponent<Rigidbody2D>().velocity = NewVelocity;
    }

    void OnBecameInvisible()
    {
        if (!TimeOut)
        {
            AudioManager.Play(AudioClipName.BallFall);
            reduceBall.Invoke(1);
            spawnBall.Invoke();
            Destroy(gameObject);
        }

        
    }

    public void SpeedUp(float multiplier)
    {
        if(BallSpeedUp == null)
            BallSpeedUp = gameObject.AddComponent<Timer>();

        if (BallSpeedUp.Running)
            BallSpeedUp.IncreaseDuration(multiplier);
        else
        {
            BallSpeedUp.TimerDuration = multiplier;
            BallSpeedUp.Run();
            GetComponent<Rigidbody2D>().velocity *= 2;
            IsSpeed = true;
        }
    }

    public void AddBallEventListener(UnityAction<int> listener)
    {
        reduceBall.AddListener(listener);
    }

    public void AddSpawnBallEventListener(UnityAction listener)
    {
        spawnBall.AddListener(listener);
    }
}
