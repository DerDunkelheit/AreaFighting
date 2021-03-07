using System;
using Data;

namespace Abilities
{
    public abstract class AbilityBase : IAbility
    {
        public event Action AbilityDepletedEvent;

        protected abstract string AbilityName { get; }
        
        public abstract void Cast();
        public abstract AbilityData GetAbilityData();
        protected void TriggerEvent() => AbilityDepletedEvent?.Invoke();
    }
}