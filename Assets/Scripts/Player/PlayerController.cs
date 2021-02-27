using System;
using Components;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public event Action PlayerDeathEven;

        private HealthComponent healthComponent;
        private PlayerMovementComponent movementComponent;

        private void Awake()
        {
            healthComponent = this.GetComponent<HealthComponent>();
            healthComponent.HealthDepletedEvent += Die;
            movementComponent = this.GetComponent<PlayerMovementComponent>();
        }

        private void Die()
        {
            PlayerDeathEven?.Invoke();
            Destroy(this.gameObject);
        }
    }
}