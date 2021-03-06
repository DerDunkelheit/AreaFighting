using System;
using Abilities;
using Components;
using Config;
using Controllers;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public event Action PlayerDeathEven;

        private HealthComponent healthComponent;
        private PlayerAbilityComponent abilityComponent;
        private PlayerConfig config;

        public Transform AbilitySpawnPoint => abilityComponent.AbilitySpawnPoint;

        private void Awake()
        {
            healthComponent = this.GetComponent<HealthComponent>();
            healthComponent.HealthDepletedEvent += Die;
            abilityComponent = this.GetComponent<PlayerAbilityComponent>();
        }

        private void Start()
        {
            config = GameManager.instance.gameConfig.playerConfig;
        }

        private void Update()
        {
            if (Input.GetKeyDown(config.abilityKey))
            {
                abilityComponent.TriggerAbility();
            }
        }

        public void SetAbility(IAbility newAbility)
        {
            abilityComponent.SetAbility(newAbility);
        }

        private void Die()
        {
            PlayerDeathEven?.Invoke();
            Destroy(this.gameObject);
        }
    }
}