using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryImpl : MonoBehaviour, Inventory
{
    private int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCoins() {
        return coins;
    }

    public void SetCoins(int newCoins) {
        coins = newCoins;
    }
}
