using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private WalkProfile WalkProfile;
    [SerializeField] private Animator animator;
  

    
    private PlayerController ph;
    private Vector2 movement;
    private Rigidbody2D rb;
    private int damage = 1;
    private int health = 1;
    
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        /*GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go != null)
        {
            ph = go.GetComponent<PlayerController>();
        }*/
    }
    
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle + 270f;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        CharacterMovement(movement);
    }

    

    void CharacterMovement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position+(direction * WalkProfile._speed * Time.deltaTime));
        animator.Play("EnemyWalk");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        /*if (col.CompareTag("Player"))
        {
            ph.health = ph.health - damage;
            ph.UpdateHealth();
        }*/
         if (col.CompareTag("Bullet"))         
        {
            if (health != 0)
            {
                health -= 1;
                
            }             
            else if (health == 0)
            {
                Destroy(gameObject);
                SoundManager.instance.Play(SoundManager.SoundName.Zombie_Die);
            }
            
        }
    }
    
}
