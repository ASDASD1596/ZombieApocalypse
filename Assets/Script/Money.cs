using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _value = 1;
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            MoneyCounter.Instance.GetCoin(_value);
            Destroy(this.gameObject);
        }
    }
}
