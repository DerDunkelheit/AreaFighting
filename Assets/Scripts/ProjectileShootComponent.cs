using UnityEngine;

public class ProjectileShootComponent : MonoBehaviour, IShooting
{
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float projectileSpeed = 2f;
    [SerializeField] private float fireRate = 1f;
    
    private float timer;

    public void Shoot(Vector2 positionToShoot)
    {
        if (timer <= 0)
        {
            GameObject projectile = Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity =
                (positionToShoot - (Vector2)projectile.transform.position).normalized * projectileSpeed;
            timer = fireRate;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}