using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float selfDestroyTime = 5f;

    private void Start()
    {
        Destroy(this.gameObject, selfDestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamageable>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        
        Destroy(this.gameObject);
    }
}