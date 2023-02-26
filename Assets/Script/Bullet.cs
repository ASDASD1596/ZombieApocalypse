using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (col.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }
}
