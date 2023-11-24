using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : Singleton<PlayerShot>
{
    [SerializeField] private float shotSpeed = 50;
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject playerShot;
    [SerializeField] private Animator animator;
    public float delayShot;
    private float nextShot;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
            
        }
    }

    void Shoot()
    {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + delayShot;
            GameObject bullet = Instantiate(playerShot, gun.position, gun.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(gun.up * shotSpeed,ForceMode2D.Impulse);
            SoundManager.instance.Play(SoundManager.SoundName.Gunshot);
            animator.Play("PlayerShoot");
        }
        
    }
}
