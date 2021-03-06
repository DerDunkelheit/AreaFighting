using UnityEngine;

namespace Projectiles
{
    [CreateAssetMenu(menuName = "Projectile Data", fileName = "New Projectile Data")]
    public class ProjectileData : ScriptableObject
    {
        public Sprite projectileSprite;
        public float moveSpeed;
        public float damage;
    }
}
