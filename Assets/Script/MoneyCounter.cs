using TMPro;

public class MoneyCounter : Singleton<MoneyCounter>
{
    public TMP_Text moneyDisplay;
    public int totalCoins;

    void Start()
    {
        moneyDisplay.text = totalCoins.ToString();
    }

    public void GetCoin(int v)
    {
        totalCoins += v;
        moneyDisplay.text = totalCoins.ToString();
    }
    
    public void SpendCoin(int v)
    {
        totalCoins -= v;
        moneyDisplay.text = totalCoins.ToString();
    }
    
    public void UpdateMoney()
    {
        moneyDisplay.text = totalCoins.ToString();
    }
}
