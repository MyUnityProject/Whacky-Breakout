using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block {


    // Use this for initialization
    protected override void Start () {
        base.Start();
        points = ConfigurationUtils.BonusBlockPoints;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
