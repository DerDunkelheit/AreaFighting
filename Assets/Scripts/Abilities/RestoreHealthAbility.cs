using System;
using Components;
using Data;

namespace Abilities
{
    public class RestoreHealthAbility : IAbility
    {
        public event Action AbilityDepletedEvent;

        private HealthComponent healthComponent;
        private float healthAmount;

        public RestoreHealthAbility(HealthComponent healthComponent, float healthAmount)
        {
            this.healthComponent = healthComponent;
            this.healthAmount = healthAmount;
        }

        public void Cast()
        {
            healthComponent.RestoreHealth(healthAmount);
        }

        public AbilityData GetAbilityData()
        {
            //TODO: create sprite for that ability and put it in resources provider.
            return new AbilityData {abilityName = "Restore Health"};
        }
    }
}