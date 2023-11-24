using UnityEngine;

public class UpgradeStats : Singleton<UpgradeStats>
{
    public int damageCost = 5;
    public int firerateCost = 5;
    public int healthCost = 5;

    private float _firerateMultiplier = 1.25f;

    public void IncreaseDamge()
    {
        if (MoneyCounter.Instance.totalCoins < damageCost)
        {
            Debug.Log("Not enough money");
            return;
        }
        
        MoneyCounter.Instance.SpendCoin(healthCost);
        PlayerController.Instance.playerDamage++;
        
        InterfaceManager.Instance.CheckPocket();
    }

    public void IncreaseFirerate()
    {
        if (MoneyCounter.Instance.totalCoins < firerateCost)
        {
            Debug.Log("Not enough money");
            return;
        }
        
        MoneyCounter.Instance.SpendCoin(healthCost);
        PlayerShot.Instance.delayShot *= _firerateMultiplier;
        
        InterfaceManager.Instance.CheckPocket();
    }
    
    public void IncreaseHealthPoint()
    {
        if (MoneyCounter.Instance.totalCoins < healthCost)
        {
            Debug.Log("Not enough money");
            return;
        }
        else if (PlayerController.Instance.currentMaxHealth >= 9)
        {
            Debug.Log("Heart Limit");
            return;
        }
        
        MoneyCounter.Instance.SpendCoin(healthCost);
        PlayerController.Instance.MaxHealthIncrement(1);
        
        InterfaceManager.Instance.CheckPocket();
    }
}
