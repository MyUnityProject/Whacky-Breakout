using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FreezeBlock : Block {

    // Use this for initialization
    FreezeEffectEvent freezeEffectEvent = new FreezeEffectEvent();

    protected override void Start()
    {
        base.Start();
        points = ConfigurationUtils.FreezeBlockPoints;
        isPickup = true;
        EventManager.AddFreezeInvoker(this);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        base.OnCollisionEnter2D(coll);
        freezeEffectEvent.Invoke(ConfigurationUtils.FreezeDuration);

    }

    public void AddFreezeEventListener(UnityAction<float> listener)
    {
        freezeEffectEvent.AddListener(listener);
    }
}
