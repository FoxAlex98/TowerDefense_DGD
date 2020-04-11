using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    [SerializeField] float health;

    void Awake()
    {
        instance = this;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            CoinManager.instance.SaveCoins();
            Time.timeScale = 0;
        }
    }

    void Start()
    {
        
    }
}
