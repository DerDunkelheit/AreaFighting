using System;
using Abilities;
using Components;
using Player;
using UnityEngine;

namespace PickupableObjects
{
    public class HealAbilityPickup : MonoBehaviour
    {
        [SerializeField] private float healthAmount = 2;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>()
                    .SetAbility(new RestoreHealthAbility(other.GetComponent<HealthComponent>(), healthAmount));
                
                Destroy(this.gameObject);
            }
        }
    }
}