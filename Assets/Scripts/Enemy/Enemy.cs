using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Enemy : MonoBehaviour, IKillable<float> {

    protected float health;//vita corrente
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int coins;
    [SerializeField] protected Transform[] checkPoints;
    [SerializeField] protected Transform target;
    [SerializeField] protected float strength, rotationSpeed;
    [SerializeField] protected Image lifeBar;
    protected int targetIndex;
    protected Animator animator;

    void Awake()
    {
        TakeCheckPoints();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        lifeBar.transform.LookAt(Camera.main.transform.position);    
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

    public virtual void TakeCheckPoints()
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
        //float t = 0;
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

    public virtual void Reset()
    {
        health = maxHealth;
        target = checkPoints[0];
        targetIndex = 0;
        lifeBar.fillAmount = 1;
        //StartCoroutine("RotateToTarget");
    }

    protected virtual void OnEnable()//viene chiamato automaticamente quando il GameObject viene attivato, ogni volta che viene attivato
    {
        Reset();        
    }

    public void Hit(float damage)
    {
        health -= damage;
        float fill = health / maxHealth;
        lifeBar.fillAmount = fill;
        Debug.Log("HIT " + health);
        animator.Play("HIT");
        Kill();
    }

    public void Kill()
    {
        if (health <= 0)
        {
            SoundManager.instance.PlayEnemyDestroy();
            CoinManager.instance.AddCoins(coins);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    public void Spawn(Transform spawnPoint)
    {
        transform.Spawn(spawnPoint);
    }

    public void Spawn(Transform spawnPoint, float y)//per gli elementi aerei
    {
        transform.Spawn(spawnPoint);
        transform.Translate(Vector3.up * y);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    
}
