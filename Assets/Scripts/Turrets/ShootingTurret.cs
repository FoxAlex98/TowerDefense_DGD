using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTurret : MainTurret {

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject[] bulletList;
    [SerializeField] private int bulletLenght;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeToSpawn;
    private int bulletCounter = 0;
    private bool bulletFound = false;

    void Awake()
    {
        bulletList = new GameObject[bulletLenght];
        for (int i = 0; i < bulletLenght; i++)
        {
            bulletList[i] = GameObject.Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            bulletList[i].GetComponent<HitBullet>().SetBulletType((int)myTurret);
            bulletList[i].SetActive(false);
        }
    }

    IEnumerator Shoot()//cooroutine
    {
        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(timeToSpawn);
        }

    }

    public void SpawnBullet()
    {
        bulletFound = false;
        while (!bulletFound)
        {
            for (int i = bulletCounter; i < bulletLenght; i++)
            {
                if (!bulletList[i].activeInHierarchy)
                {
                    bulletList[i].GetComponent<Bullet>().Spawn(spawnPoint);
                    bulletCounter = i + 1;
                    bulletFound = true;
                    break;
                }
                if (i == bulletLenght - 1)
                {
                    bulletCounter = 0;
                }
            }
            if (bulletCounter == bulletLenght)
            {
                Debug.Log("ho finito i colpi");
                bulletCounter = 0;
            }
        }
    }
}
