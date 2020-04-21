using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy {

    float t = 0;
    [SerializeField] protected float timeToReach;
    

    protected override void Start()
    {
        StartCoroutine("MoveHelicopter");
    }

    IEnumerator MoveHelicopter()
    {
        t = 0;
        Vector3 actualPosition = transform.position;
        Vector3 targetPosition = target.position;

        while (true)
        {
            t += Time.deltaTime / timeToReach;
            transform.position = new Vector3(Mathf.Lerp(actualPosition.x, targetPosition.x, t),actualPosition.y, Mathf.Lerp(actualPosition.z, targetPosition.z, t));
            yield return 0;
        }
    }

    public override void TakeCheckPoints()
    {
        GameObject aux = GameObject.Find("CheckPoints");
        checkPoints = new Transform[aux.transform.childCount];
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i] = aux.transform.GetChild(i);
        }
        target = checkPoints[checkPoints.Length-1];
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        TakeCheckPoints();//esercizio chiamarlo solo una volta
        StartCoroutine("MoveHelicopter");
    }
}
