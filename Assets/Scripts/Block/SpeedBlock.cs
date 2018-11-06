using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedBlock : Block {

    FreezeEffectEvent freezeEffectEvent = new FreezeEffectEvent();

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        points = ConfigurationUtils.SpeedBlockPoints;
        isPickup = true;
        EventManager.AddSpeedInvoker(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        base.OnCollisionEnter2D(coll);
        freezeEffectEvent.Invoke(ConfigurationUtils.FreezeDuration);
    }

    public void AddSpeedEventListener(UnityAction<float> listener)
    {
        freezeEffectEvent.AddListener(listener);
    }
}
