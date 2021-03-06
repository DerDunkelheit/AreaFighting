using System.Collections;
using Components;
using UnityEngine;

namespace Projectiles
{
    public class AbilityProjectile : ProjectileBase
    {
        protected override void SetupInitialConfigurations()
        {
            spriteRenderer.sprite = data.projectileSprite;
            this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        protected override IEnumerator ProjectileAnimationRoutine()
        {
            Debug.Log($"animation duration :3");
            yield return new WaitForSeconds(3f);
            Debug.Log($"Done");
        }

        protected override IEnumerator LoopRoutine()
        {
            yield return base.LoopRoutine();
            Debug.Log($"projectile moves with {data.moveSpeed} speed");
        }

        //TODO: upgrade this class, so it can use enemies as well.
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.TryGetComponent(out HealthComponent healthComponent))
                {
                    healthComponent.TakeDamage(data.damage);
                }
                    
            }
        }
    }
}
