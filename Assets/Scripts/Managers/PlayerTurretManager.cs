using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretManager : MonoBehaviour {

    [SerializeField] GameObject turret;
    RaycastHit hit;
    [SerializeField] LayerMask layerMask;
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                GameObject aux = GameObject.Instantiate(turret, hit.point, hit.transform.rotation);
            }
        }	
	}
}
