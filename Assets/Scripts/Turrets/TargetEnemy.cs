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

    private Animator animator;
    private GameObject target, turret;
    private Quaternion rotation;
    //turret per assegnarlo come torretta, il figlio della base

    private void Update()
    {
        if(target != null)
        {
            if ((target.activeInHierarchy))
            {
                turret.transform.LookAt(target.transform.position);
            }
            else
                Deactivate();
        }
    }

    void Awake()
    {
        turret = transform.GetChild(0).gameObject;
        rotation = turret.transform.rotation;
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            target = other.gameObject;
            Debug.Log("Ho incontrato un nemico");
            animator.SetBool("Spotted", true);
            GetComponent<MachineGun>().StartCoroutine("Shoot");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        animator.SetBool("Spotted", false);
        Debug.Log("Deactivate");
        target = null;
        turret.transform.rotation = rotation;
        GetComponent<MachineGun>().StopAllCoroutines();
    }
}
