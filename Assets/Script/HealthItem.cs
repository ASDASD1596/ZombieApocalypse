using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private PlayerController ph;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ph.health = ph.health + 1  ;
            ph.UpdateHealth();
            Destroy(this.gameObject);
            SoundManager.instance.Play(SoundManager.SoundName.PickUpitem);
        }
    }
}
