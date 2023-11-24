using TMPro;

public class MoneyCounter : Singleton<MoneyCounter>
{
    public TMP_Text moneyDisplay;

    void Start()
    {
        moneyDisplay.text = Money.Instance.totalCoins.ToString();
    }

    public void GetCoin(int v)
    {
        Money.Instance.totalCoins += v;
        moneyDisplay.text = Money.Instance.totalCoins.ToString();
    }
}
