using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : Singleton<PlayerController>
{

    [SerializeField] private WalkProfile walkProfile;
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody2D rb;

    public int health = 3;
    [SerializeField] private Image[] heart;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite damagedHeart;
    public int playerDamage = 1;
    
    private Vector2 _movementNewInput;
    private Vector2 _movement;
    private Vector2 _mousePosition;
    private float _angularOffset = 90f;
    
    private void Start()
    {
        UpdateHealth();
    }

    void Move()
    {
        transform.position += (Vector3) _movementNewInput * walkProfile._speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Move();

        Vector2 lookDirection = _mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - _angularOffset;
        rb.rotation = angle;
    }

    void OnMove(InputValue moveValue)
    {
        _movementNewInput = moveValue.Get<Vector2>();
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
                if (health <= 0)
                {
                    SceneManager.LoadScene("PlayerDead");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.TryGetComponent(out EnemyController enemy);
            
            if (health > 0)
            {
                health -= enemy._damage;
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
    
    //TODO: Add feature to increase max health
}
