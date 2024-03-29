﻿using Components;
using UnityEngine;

namespace Player
{
    //TODO: create a base ability controller in order to give enemies also capability to cast an ability.
    public class PlayerAbilityComponent : BaseComponent
    {
        [SerializeField] private float abilityCoolDown = 10;
        
        private IAbility currentAbility;
        private float timer;

        protected override bool AllowInput => true;
        
        protected override void HandleAbility()
        {
            base.HandleAbility();

            timer -= Time.deltaTime;
            if (timer < -10000)
            {
                timer = 0;
            }
        }

        public void SetAbility(IAbility newAbility)
        {
            currentAbility = newAbility;
        }

        public void TriggerAbility()
        {
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
    }
}
