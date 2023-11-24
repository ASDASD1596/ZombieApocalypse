using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject coinDrop;
    
    [SerializeField] protected WalkProfile walkProfile;
    [SerializeField] protected Animator animator;
    [SerializeField] protected int _health = 10;
    public int _damage = 1;

    protected Vector2 _movement;
    protected Rigidbody2D _rb;
    protected Transform _player;
    protected float _angularOffset = 270f;
    
    protected virtual void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _player = PlayerController.Instance.transform;
    }

    protected virtual void Update()
    {
        Vector3 direction = _player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle + _angularOffset;
        direction.Normalize();
        _movement = direction;
    }

    protected virtual void FixedUpdate()
    {
        CharacterMovement(_movement);
    }

    protected virtual void CharacterMovement(Vector2 direction)
    {
        _rb.MovePosition((Vector2)transform.position+(direction * walkProfile._speed * Time.deltaTime));
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))         
        {
            TakeDamage();
                        
            if(_health <= 0)
            {
                Destroy(gameObject);
                Instantiate(coinDrop, transform.position, Quaternion.identity);
                SoundManager.Instance.Play(SoundManager.SoundName.Zombie_Die);
            }
            
        }
    }

    protected virtual void TakeDamage()
    {
        _health -= PlayerController.Instance.playerDamage;
    }
}
