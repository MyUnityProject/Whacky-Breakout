using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    float halfwidth;
    float halfheight;
    float BounceAngleHalfRange;
    Timer freezeTimer;

	// Use this for initialization
	void Start () {
        EventManager.AddFreezeListener(FreezePaddle);
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        halfwidth = boxCollider.size.x / 2;
        halfheight = boxCollider.size.y / 2;
        BounceAngleHalfRange = Mathf.Deg2Rad * 60;
        freezeTimer = gameObject.AddComponent<Timer>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            MenuManager.GoToMenu(MenuName.PauseMenu);

    }

    private void FixedUpdate()
    {
        if (!freezeTimer.Running)
        {
            Vector2 currentPosition = rb.position;
            currentPosition.x = CalculateNewPosition(currentPosition.x);
            rb.MovePosition(currentPosition);
        }

    }

    private float CalculateNewPosition(float currentXPosition)
    {
        float NewXPosition = currentXPosition + ConfigurationUtils.PaddleMoveUnitsPerSecond * Input.GetAxis("PaddleMoveHorizontal");
        if (NewXPosition - halfwidth < ScreenUtils.ScreenLeft)
            return ScreenUtils.ScreenLeft + halfwidth;
        if (NewXPosition + halfwidth > ScreenUtils.ScreenRight) 
            return ScreenUtils.ScreenRight - halfwidth;
        return NewXPosition;

    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        AudioManager.Play(AudioClipName.HitPaddle);
        float ballHeight = coll.gameObject.transform.position.y - coll.gameObject.GetComponent<BoxCollider2D>().size.y;
        if (coll.gameObject.CompareTag("Ball") && ballHeight > (transform.position.y - halfheight))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x - coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter / halfwidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    void FreezePaddle(float Duration)
    {
        if (freezeTimer.Running)
            freezeTimer.IncreaseDuration(Duration);
        else
        {
            freezeTimer.TimerDuration = Duration;
            freezeTimer.Run();
        }
    }
}
