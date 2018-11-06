using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour {

    protected int points = 1;
    protected bool isPickup = false;

    IntEvent pointEvent = new IntEvent();


	// Use this for initialization
	protected virtual void Start () {
        points = ConfigurationUtils.StdBlockPoints;
        EventManager.AddPointInvoker(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        AudioManager.Play(AudioClipName.HitBlock);
        pointEvent.Invoke(points);
        Destroy(gameObject);
    }

    public void AddPointEventListener(UnityAction<int> listener)
    {
        pointEvent.AddListener(listener);
    }
}
