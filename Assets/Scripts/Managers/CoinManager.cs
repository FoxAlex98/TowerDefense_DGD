using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    public static CoinManager instance;
    [SerializeField] private int coins;

	void Awake () {
        instance = this; //instance
	}

    void Start()
    {
        coins = SaveGame.GetCoins();        
    }

    public void AddCoins(int coinToAdd)
    {
        coins += coinToAdd;
    }

    public void SaveCoins()
    {
        SaveGame.SaveCoins(coins);
    }
}
