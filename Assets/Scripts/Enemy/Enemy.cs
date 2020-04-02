using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float health;//vita corrente
    [SerializeField] private int maxHealth;
    [SerializeField] private int coins;

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
