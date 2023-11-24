using UnityEngine;

public class UpgradeStats : Singleton<UpgradeStats>
{
    public int damageCost = 5;
    public int firerateCost = 5;
    public int healthCost = 5;
    
    private Money _money;
    private PlayerController _playerController;
    
    private float _firerateMultiplier = 1.25f;

    private void Start()
    {
        _playerController = PlayerController.Instance;
        _money = Money.Instance;
    }

    public void IncreaseDamge()
    {
        if (_money.totalCoins < damageCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        _money.totalCoins -= damageCost;
        PlayerController.Instance.playerDamage++;
    }

    public void IncreaseFirerate()
    {
        if (_money.totalCoins < firerateCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        _money.totalCoins -= firerateCost;
        
        PlayerShot.Instance.delayShot *= _firerateMultiplier;
    }
    
    public void IncreaseHealthPoint()
    {
        if (Money.Instance.totalCoins < healthCost)
        {
            Debug.Log("Not enough money");
            return;
        }
        else if (PlayerController.Instance.maxHealth >= 9)
        {
            Debug.Log("Heart Limit");
            return;
        }

        Money.Instance.totalCoins -= healthCost;
        PlayerController.Instance.MaxHealthIncrement(1);
    }
}
