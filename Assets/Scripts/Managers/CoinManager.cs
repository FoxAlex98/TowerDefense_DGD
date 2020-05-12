using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

    public static CoinManager instance;
    [SerializeField] Text coinText;
    [SerializeField] private int coins;

	void Awake () {
        instance = this; //instance
	}

    void Start()
    {
        coins = SaveGame.GetCoins();
        coinText.text = coins.ToString();
    }

    public void AddCoins(int coinToAdd)
    {
        coins += coinToAdd;
        coinText.text = coins.ToString();
    }

    public void SaveCoins()
    {
        SaveGame.SaveCoins(coins);
    }
}
