using System;
using Components;
using UnityEngine;

namespace Player
{
    //TODO: create a base ability controller in order to give enemies also capability to cast an ability.
    public class PlayerAbilityComponent : BaseComponent
    {
        public event Action<IAbility> AbilityEquippedEvent; 
        
        [SerializeField] private Transform abilitySpawnPoint = null;
        [SerializeField] private float abilityCoolDown = 10;
        
        private IAbility currentAbility;
        private float timer;

        public Transform AbilitySpawnPoint => abilitySpawnPoint;

        protected override bool AllowInput => true;
        
        protected override void HandleAbility()
        {
            base.HandleAbility();

            ReduceAbilityCooldown();
        }

        private void ReduceAbilityCooldown()
        {
            timer -= Time.deltaTime;
            if (timer < -10000)
            {
                timer = 0;
            }
        }

        public void SetAbility(IAbility newAbility)
        {
            currentAbility = newAbility;
            currentAbility.AbilityDepletedEvent += OnAbilityDepleted;
            timer = 0;
            
            AbilityEquippedEvent?.Invoke(currentAbility);
        }

        public void TriggerAbility()
        {
            if (currentAbility == null)
            {
                Debug.Log($"You have no ability to use!");
                return;
            }
            
            if (CanUseAbility())
            {
                currentAbility.Cast();
                timer = abilityCoolDown;
            }
            else
            {
                Debug.Log($"Cooldown, wait: {timer}");
            }
        }

        private bool CanUseAbility() => timer <= 0;

        private void OnAbilityDepleted()
        {
            Debug.Log($"there is no more ability charges");
            currentAbility.AbilityDepletedEvent -= OnAbilityDepleted;
            currentAbility = null;
            
            AbilityEquippedEvent?.Invoke(currentAbility);
        }
    }
}
