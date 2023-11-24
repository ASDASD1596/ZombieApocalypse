using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private PlayerController ph;
    [SerializeField] private int healthIncrement = 1;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(PlayerController.Instance.health >= PlayerController.Instance.currentMaxHealth) return;
            
            ph.HealthIncrement(healthIncrement);

            Destroy(this.gameObject);
            SoundManager.Instance.Play(SoundManager.SoundName.PickUpitem);
        }
    }
    
    public void SetHealthIncrement(int healthIncrement)
    {
        this.healthIncrement = healthIncrement;
    }
}
