using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float health;//vita corrente
    [SerializeField] private int maxHealth;
    [SerializeField] private int coins;
    [SerializeField] protected Transform[] checkPoints;
    [SerializeField] protected Transform target;
    [SerializeField] protected float strength, rotationSpeed;
    private int targetIndex;

    protected virtual void Start()
    {
        TakeCheckPoints();
        StartCoroutine("RotateToTarget");//sempre valida fino alla fine del tragitto
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            if(other.gameObject.tag != "End")
            {
                targetIndex++;
                target = checkPoints[targetIndex];
            }
            else
            {
                gameObject.SetActive(false);
                PlayerManager.instance.TakeDamage(strength);
            }
            
            //StartCoroutine("RotateToTarget");
        }
    }

    public void TakeCheckPoints()
    {
        GameObject aux = GameObject.Find("CheckPoints");
        checkPoints = new Transform[aux.transform.childCount];
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i] = aux.transform.GetChild(i);
        }
        target = checkPoints [0];
        targetIndex = 0;
    }

    IEnumerator RotateToTarget()//ruotare verso il target
    {
        Vector3 direction;
        Quaternion lookRotation;
        float t = 0;
        while (true)
        {
            direction = target.position - transform.position;
            lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            yield return 0;
        }
        /*
        Vector3 direction;
        Quaternion lookRotation;
        direction = target.position - transform.position;
        lookRotation = Quaternion.LookRotation(direction);
        float t = 0;
        while (t<1)
        {
            t += Time.deltaTime / rotationSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, t);
            yield return 0;
        }
        StopCoroutine("RotateToTarget");
        */
    }

    private void OnEnable()//viene chiamato automaticamente quando il GameObject viene attivato, ogni volta che viene attivato
    {
        health = maxHealth;
    }

    public void Hit(int damage)
    {
        health -= damage;
        Debug.Log("HIT " + health);
        if (health <= 0)
        {
            CoinManager.instance.AddCoins(coins);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    public void Spawn(Transform spawnPoint)
    {
        transform.Spawn(spawnPoint);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
