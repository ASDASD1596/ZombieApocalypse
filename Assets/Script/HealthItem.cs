using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private PlayerController ph;
    [SerializeField] private int healthIncrement = 1;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ph.health += healthIncrement;
            ph.UpdateHealth();
            Destroy(this.gameObject);
            SoundManager.Instance.Play(SoundManager.SoundName.PickUpitem);
        }
    }
    
    public void SetHealthIncrement(int healthIncrement)
    {
        this.healthIncrement = healthIncrement;
    }
}
