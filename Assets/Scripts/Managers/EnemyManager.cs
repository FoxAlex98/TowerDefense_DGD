using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] enemyList;
    [SerializeField] private int enemyLenght;
    public Transform spawnPoint;
    [SerializeField] float timeToSpawn;
    [SerializeField] private float yFlyin;
    float tEnemySpawn = 0;
    int enemyCounter = 0;

    void Awake()
    {
        
    }

    void Start () {
        enemyList = new GameObject[enemyLenght];
        for(int i = 0; i < enemyLenght; i++){
            enemyList[i] = GameObject.Instantiate(enemy[Random.Range(0,2)], spawnPoint.position, spawnPoint.rotation);
            enemyList[i].SetActive(false);
        }
	}
    
    public GameObject GetItem()
    {
        return enemyList[0];
    }
	
	// Update is called once per frame
	void Update () {
        tEnemySpawn += Time.deltaTime;
        if(tEnemySpawn > timeToSpawn)
        {
            SpawnEnemy();
        }
	}

    void SpawnEnemy()
    {
        tEnemySpawn = 0;
        for(int i = enemyCounter; i < enemyLenght; i++)
        {
            if (!enemyList[i].activeInHierarchy)
            {
                //Debug.Log("sono il nemico " + enemyList[i].GetComponent<Enemy>());
                if (enemyList[i].tag == "Helicopter")
                    enemyList[i].GetComponent<Enemy>().Spawn(spawnPoint, yFlyin);
                else
                    enemyList[i].GetComponent<Enemy>().Spawn(spawnPoint);

                enemyCounter = i + 1;
                break;
            }
            if (enemyCounter == enemyLenght)
            {
                enemyCounter = 0; //lo riportiamo all'inizio
            }
        }
    }
}
