using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour {

    /*
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
    }
    */

    private GameObject target, turret;
    private Quaternion rotation;
    //turret per assegnarlo come torretta, il figlio della base

    private void Update()
    {
        if (target != null)
        {
            turret.transform.LookAt(target.transform.position);
        }
    }

    void Awake()
    {
        turret = transform.GetChild(0).gameObject;
        rotation = turret.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            target = other.gameObject;
            Debug.Log("Ho incontrato un nemico");
            GetComponent<MachineGun>().StartCoroutine("Shoot");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            target = null;
            turret.transform.rotation = rotation;
            GetComponent<MachineGun>().StopAllCoroutines();
        }
    }
}
