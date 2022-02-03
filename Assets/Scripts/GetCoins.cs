using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetCoins : MonoBehaviour
{
   // public static int coinsCount;
    public GameObject coinsDisplay;
    public int internalCoins;
    // Update is called once per frame
    void Update()
    {
        internalCoins = PlayerStats.Money;
        coinsDisplay.GetComponent<Text>().text = "Coins: " + internalCoins;
    }
}