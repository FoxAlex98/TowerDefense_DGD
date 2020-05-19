using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buggy : GroundEnemy {

    public void ResetHit()
    {
        animator.SetBool("Hit", false);
    }

    public void DoSometing(string s)
    {
        //Debug.Log(s);
    }
}
