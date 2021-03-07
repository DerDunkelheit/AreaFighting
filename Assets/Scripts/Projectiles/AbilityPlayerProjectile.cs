using System.Collections;
using Components;
using DG.Tweening;
using UnityEngine;

namespace Projectiles
{
    //TODO: upgrade this class, so it can use enemies as well. Create AbilityEnemyProjectile
    public class AbilityPlayerProjectile : ProjectileBase
    {
        private Transform target;

        protected override void SetupInitialConfigurations()
        {
            spriteRenderer.sprite = data.projectileSprite;
            this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        protected override IEnumerator ProjectileAnimationRoutine()
        {
            //TODO: remove hardcoded animation time.
            var tweenAnim = this.transform.DOScale(Vector3.one, 1f);
            yield return new WaitUntil(() => !tweenAnim.IsActive());

            if (!FindNearestEnemy(out target))
            {
                Destroy(this.gameObject);
                yield return null;
            }
        }

        protected override IEnumerator LoopRoutine()
        {
            //TODO: if enemy destroys, null error appears.
            while (true)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, target.position,
                    data.moveSpeed * Time.deltaTime);

                yield return null;
            }
        }

        private bool FindNearestEnemy(out Transform nearestTransform)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                nearestTransform = default;
                return false;
            }

            nearestTransform = FindNearestEnemy(enemies).transform;
            return true;
        }

        private GameObject FindNearestEnemy(GameObject[] enemies)
        {
            float closestDist = float.MaxValue;
            GameObject nearestEnemy = null;

            foreach (var enemy in enemies)
            {
                var distanceBetween = Vector2.Distance(this.transform.position, enemy.transform.position);
                if (distanceBetween < closestDist)
                {
                    nearestEnemy = enemy;
                    closestDist = distanceBetween;
                }
            }

            return nearestEnemy;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.TryGetComponent(out HealthComponent healthComponent))
                {
                    healthComponent.TakeDamage(data.damage);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}