using System;
using UnityEngine;

namespace Components
{
    public class HealthComponent : BaseComponent, IDamageable,ICurable
    {
        public event Action HealthUpdatedEvent;
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
        public void RestoreHealth(float amount)
        {
            currentHealth += amount;

            if (currentHealth > initialHealth)
            {
                currentHealth = initialHealth;
            }
            
            HealthUpdatedEvent?.Invoke();
        }
    }
}