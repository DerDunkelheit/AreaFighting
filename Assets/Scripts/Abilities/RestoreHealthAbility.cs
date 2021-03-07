using System;
using Components;

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
    }
}