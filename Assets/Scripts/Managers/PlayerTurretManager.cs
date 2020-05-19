using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretManager : MonoBehaviour {

    [SerializeField] GameObject turret;
    public List<GameObject> instantiatedTurrets = new List<GameObject>();
    RaycastHit hit;
    [SerializeField] LayerMask layerMask;
	
	void Update () {

        if ((Input.GetMouseButtonDown(0)) && (turret!=null))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                GameObject aux = GameObject.Instantiate(turret, hit.point, hit.transform.rotation);
                if (!CheckIntersectionsWithTurrets(aux))
                    instantiatedTurrets.Add(aux);
                else
                    Destroy(aux);
            }
        }	
	}

    private bool CheckIntersectionsWithTurrets(GameObject aux)
    {
        if(instantiatedTurrets.Count == 0)
        {
            return false;
        }
        else
            foreach(GameObject turret in instantiatedTurrets)
            {
                if (aux.GetComponent<BoxCollider>().bounds.Intersects(turret.GetComponent<BoxCollider>().bounds))
                    return true;
            }
        return false;
    }

    public void setTurretType(GameObject turret)
    {
        this.turret = turret;
    }
}
