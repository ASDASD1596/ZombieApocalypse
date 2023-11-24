using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeStats : MonoBehaviour
{

    public PlayerController playerController;
    void Start()
    {
        //playerController.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseDamge()
    {
        PlayerController.Instance.playerDamage++;
        Debug.Log("Damge in");
        
    }

    public void IncreaseFirerate()
    {
        PlayerShot.Instance.delayShot -= ;
    }
}
