using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buggy : GroundEnemy {

	
	// Update is called once per frame
	void Update () {
        Move();
	}

    protected override void Move()
    {
        base.Move();
        //transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    public void DoSometing(string s)
    {
        //Debug.Log(s);
    }
}
