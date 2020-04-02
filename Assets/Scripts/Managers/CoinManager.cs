using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    public static CoinManager instance;
    [SerializeField] private int coins;

	void Awake () {
        instance = this; //instance
	}
	
	public void AddCoins(int coinToAdd)
    {
        coins += coinToAdd;
    }
}
