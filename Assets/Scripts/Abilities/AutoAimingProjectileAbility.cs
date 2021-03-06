using Controllers;
using Projectiles;
using UnityEngine;

namespace Abilities
{
    public class AutoAimingProjectileAbility : IAbility
    {
        private ProjectileData projectileData;
        private Transform spawnPosition;

        public AutoAimingProjectileAbility(ProjectileData projectileData, Transform spawnPosition)
        {
            this.projectileData = projectileData;
            this.spawnPosition = spawnPosition;
        }

        //TODO: use ability amount.
        public void Cast()
        {
            var projectile = Object.Instantiate(GameManager.resourcesProvider.projectileAbilityBasePrefab,
                spawnPosition.position, spawnPosition.rotation);
            projectile.GetComponent<ProjectileBase>().StartProjectile(projectileData);
        }
    }
}