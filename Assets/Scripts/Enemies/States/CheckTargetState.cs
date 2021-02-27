using Enemies.Transitions;
using UnityEngine;

namespace Enemies.States
{
    public class CheckTargetState : State
    {
        public override string Id { get; } = ProducingStateIds.CHECK_TARGET_STATE;

        public CheckTargetState(EnemyController controller) : base(controller)
        {
            AddTransition(new CheckPlayerInEnteredZoneTransition(ProducingStateIds.FOLLOW_TARGET_STATE));
        }
    }
}
