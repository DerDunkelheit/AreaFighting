using System;
using Abilities;
using Player;
using Projectiles;
using UnityEngine;

namespace PickupableObjects
{
    public class AutoAimProjectileAbilityPickup : PickupBase
    {
        [SerializeField] private ProjectileData projectileData = null;

        protected override void Pickup()
        {
            var playerController = player.GetComponent<PlayerController>();
            playerController.SetAbility(new AutoAimingProjectileAbility(projectileData,
                playerController.AbilitySpawnPoint));
        }
    }
}