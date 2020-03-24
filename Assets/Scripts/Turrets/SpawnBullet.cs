using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(Shoot());
        //StartCoroutine("Shoot");//si può fare anche così
        //StopAllCoroutines();
    }

    IEnumerator Shoot()//cooroutine
    {
        while (true)
        {
            Debug.Log("spawn bullet");
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    IEnumerator Shoot2()//cooroutine
    {
        yield return new WaitForSeconds(5);
        Debug.Log("fine shoot2");
    }
}
