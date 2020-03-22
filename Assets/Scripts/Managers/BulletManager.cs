using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject[] bulletList;
    [SerializeField] private int bulletLenght;
    public Transform spawnPoint;
    [SerializeField] private float timeToSpawn;
    private int bulletCounter = 0;
    private float tBulletSpawn = 0;

    void Awake()
    {

    }

    void Start () {

        bulletList = new GameObject[bulletLenght];
        for(int i = 0; i < bulletLenght; i++)
        {
            bulletList[i] = GameObject.Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            bulletList[i].SetActive(false);
        }
	}

    public GameObject GetItem()
    {
        return bulletList[0];
    }

    // Update is called once per frame
    void Update () {
        tBulletSpawn += Time.deltaTime;
        if(tBulletSpawn > timeToSpawn)
        {
            SpawnBullet();
        }
	}

    public void SpawnBullet()
    {
        tBulletSpawn = 0;
        for(int i = bulletCounter; i < bulletLenght; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                Debug.Log("sono il proiettile " + bulletList[i].GetComponent<Bullet>());
                bulletList[i].GetComponent<Bullet>().Spawn(spawnPoint);
                bulletCounter = i+1;
                break;
            }
            if(bulletCounter == bulletLenght)
            {
                bulletCounter = 0;
            }
        }
    }
}
