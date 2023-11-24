using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    //public TextMeshProUGUI moneyDisplay;
    //private PlayerController playerController;
    public int totalCoins;
    public int value = 1;
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            MoneyCounter.instance.GetCoin(value);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        // moneyDisplay.text = totalCoins.ToString("0");
    }

    /*[SerializeField] private TextMeshProUGUI moneyDisplay;
    private PlayerController playerController;
    public int totalCoins;
    public int Quantity = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //playerController = other.gameObject.GetComponent<PlayerController>();
        totalCoins += Quantity;
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        moneyDisplay.text = coins.ToString("0");
    }*/
}
