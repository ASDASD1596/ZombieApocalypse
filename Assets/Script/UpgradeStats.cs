using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    public int damageCost = 5;
    public int firerateCost = 5;
    
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
}
