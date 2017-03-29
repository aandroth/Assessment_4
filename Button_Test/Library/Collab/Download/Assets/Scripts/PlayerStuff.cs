using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour {

    public int karma;
    public int money;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void addKarma(int karmaToAdd)
    {
        karma += karmaToAdd;

        if (karma > 10)
            karma = 10;
        if (karma < 0)
            karma = 6;
    }

    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }
}
