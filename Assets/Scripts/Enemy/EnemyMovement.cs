using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward*speed*Time.deltaTime, Space.Self);
        //transform.Rotate(Vector3.up * speed * Time.deltaTime);
	}
}
