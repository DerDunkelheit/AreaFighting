using System;
using UnityEngine;

namespace Components
{
    public class HealthComponent : BaseComponent, IDamageable
    {
        public event Action HealthDepletedEvent;

        [SerializeField] private float initialHealth = 5;

        private float currentHealth;

        private void Awake()
        {
            currentHealth = initialHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                HealthDepletedEvent?.Invoke();
            }
        }
    }
}