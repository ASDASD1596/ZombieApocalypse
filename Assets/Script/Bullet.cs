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
        switch (col.tag)
        {
            case "Enemy":
            case "Building":
                Destroy(this.gameObject);
                break;
        }
    }
}
