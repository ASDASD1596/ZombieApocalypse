using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : Singleton<PlayerController>
{

    [SerializeField] private WalkProfile walkProfile;
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody2D rb;

    public int maxHealth = 3;
    [SerializeField] private Image[] heart;
    [SerializeField] private Sprite[] heartSprites;
    public int playerDamage = 1;

    private int health;
    
    private Vector2 _movementNewInput;
    private Vector2 _movement;
    private Vector2 _mousePosition;
    private float _angularOffset = 90f;
    
    private void Awake()
    {
        health = maxHealth;
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
    
    public void UpdateHealth()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < health)
            {
                if (health - (i+1) >= 6) heart[i].sprite = heartSprites[3];
                else if(health - (i+1) >= 3) heart[i].sprite = heartSprites[2];
                else heart[i].sprite = heartSprites[1];
            }
            else
            {
                heart[i].sprite = heartSprites[0];
                if (health <= 0)
                {
                    SceneManager.LoadScene("PlayerDead");
                }
            }
        }
    }
    
    public void HealthIncrement(int healthIncrement)
    {
        if(health >= maxHealth) return;        
        
         health += healthIncrement;
         
         UpdateHealth();
    }
    
    public void MaxHealthIncrement(int maxHealthIncrement)
    {
        maxHealth += maxHealthIncrement;
        
        health = maxHealth;
        
        UpdateHealth();
    }

    public void MapHeart(Image[] h)
    {
        heart = new Image[h.Length];
        heart = h;
        
        UpdateHealth();
    }

    [ContextMenu("Add Health")]
    private void PlusOneHealth()
    {
        HealthIncrement(2);
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
