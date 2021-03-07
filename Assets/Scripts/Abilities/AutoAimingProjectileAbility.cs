using System;
using Controllers;
using Data;
using Projectiles;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Abilities
{
    public class AutoAimingProjectileAbility : IAbility
    {
        public event Action AbilityDepletedEvent;
        
        private ProjectileData projectileData;
        private Transform spawnPosition;
        private int abilityCharges;
        

        public AutoAimingProjectileAbility(ProjectileData projectileData, Transform spawnPosition,int abilityCharges = Int32.MaxValue)
        {
            this.projectileData = projectileData;
            this.spawnPosition = spawnPosition;
            this.abilityCharges = abilityCharges;
        }
        
        public void Cast()
        {
            var projectile = Object.Instantiate(GameManager.resourcesProvider.projectileAbilityBasePrefab,
                spawnPosition.position, spawnPosition.rotation);
            projectile.GetComponent<ProjectileBase>().StartProjectile(projectileData);
            
            ReduceCharges();
        }

        public AbilityData GetAbilityData()
        {
            //TODO: remove hardcoded name.
            return new AbilityData {abilitySprite = projectileData.projectileSprite, abilityName = "Projectile"};
        }

        private void ReduceCharges()
        {
            abilityCharges -= 1;

            if (abilityCharges <= 0)
            {
                AbilityDepletedEvent?.Invoke();
            }
        }
    }
}