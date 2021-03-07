using System;
using Components;
using Data;

namespace Abilities
{
    public class RestoreHealthAbility : AbilityBase
    {
        private HealthComponent healthComponent;
        private float healthAmount;

        protected override string AbilityName => "Restore Health";

        public RestoreHealthAbility(HealthComponent healthComponent, float healthAmount)
        {
            this.healthComponent = healthComponent;
            this.healthAmount = healthAmount;
        }

        public override void Cast()
        {
            healthComponent.RestoreHealth(healthAmount);
        }

        public override AbilityData GetAbilityData()
        {
            //TODO: create sprite for that ability and put it in resources provider.
            return new AbilityData {abilityName = AbilityName};
        }
    }
}