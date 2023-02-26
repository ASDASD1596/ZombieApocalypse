using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private WalkProfile walkProfile;
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody2D rb;

    public int health = 3;
    [SerializeField] private Image[] heart;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite damagedHeart;

    private Vector2 movementNewInput;
    private Vector2 movement;
    private Vector2 mousePosition;
    

    private void Start()
    {
        UpdateHealth();
    }

    void Move()
    {
        transform.position += (Vector3) movementNewInput * walkProfile._speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Move();

        mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;


    }

    void OnMove(InputValue moveValue)
    {
        movementNewInput = moveValue.Get<Vector2>();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < health)
            {
                heart[i].sprite = fullHeart;
            }
            else
            {
                heart[i].sprite = damagedHeart;
                if (health == 0)
                {
                    SceneManager.LoadScene("PlayerDead");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            //SoundManager.instance.Play(SoundManager.SoundName.);
            if (health != 0)
            {
                health -= 1;
            }             
            //StartCoroutine(Invulnerability());
            UpdateHealth();
        }
        
    }

    /*IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6,7);
        color.a = 0.5f;
        rend.material.color = color;
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6,7, false);
        color.a = 1f;
        rend.material.color = color;
    }*/


}
