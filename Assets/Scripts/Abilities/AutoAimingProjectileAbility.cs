using System;
using Controllers;
using Data;
using Projectiles;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Abilities
{
    public class AutoAimingProjectileAbility : AbilityBase
    {

        private ProjectileData projectileData;
        private Transform spawnPosition;
        private int abilityCharges;

        protected override string AbilityName => "Projectile";
        
        public AutoAimingProjectileAbility(ProjectileData projectileData, Transform spawnPosition,int abilityCharges = Int32.MaxValue)
        {
            this.projectileData = projectileData;
            this.spawnPosition = spawnPosition;
            this.abilityCharges = abilityCharges;
        }

        public override void Cast()
        {
            var projectile = Object.Instantiate(GameManager.resourcesProvider.projectileAbilityBasePrefab,
                spawnPosition.position, spawnPosition.rotation);
            projectile.GetComponent<ProjectileBase>().StartProjectile(projectileData);
            
            ReduceCharges();
        }

        public override AbilityData GetAbilityData()
        {
            return new AbilityData {abilitySprite = projectileData.projectileSprite, abilityName = AbilityName};
        }

        private void ReduceCharges()
        {
            abilityCharges -= 1;

            if (abilityCharges <= 0)
            {
                TriggerEvent();
            }
        }
    }
}