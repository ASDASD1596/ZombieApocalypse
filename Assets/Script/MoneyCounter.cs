using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{ public static MoneyCounter instance;
    public TMP_Text moneyDisplay;
    public int totalCoins = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        moneyDisplay.text = totalCoins.ToString();
    }

    // Update is called once per frame
   

    public void GetCoin(int v)
    {
        totalCoins += v;
        moneyDisplay.text = totalCoins.ToString();
        
    }
}
