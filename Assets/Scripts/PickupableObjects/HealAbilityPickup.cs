using System;
using Abilities;
using Components;
using Player;
using UnityEngine;

namespace PickupableObjects
{
    public class HealAbilityPickup : PickupBase
    {
        [SerializeField] private float healthAmount = 2;

        protected override void Pickup()
        {
            player.GetComponent<PlayerController>()
                .SetAbility(new RestoreHealthAbility(player.GetComponent<HealthComponent>(), healthAmount));
        }
    }
}