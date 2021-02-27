using Enemies.Transitions;

namespace Enemies.States
{
    public class FollowTargetState : State
    {
        public override string Id { get; } = ProducingStateIds.FOLLOW_TARGET_STATE;
    
        public FollowTargetState(EnemyController controller) : base(controller)
        {
            AddTransition(new CheckPlayerInLeftZoneTransition(ProducingStateIds.CHECK_TARGET_STATE));
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            controller.GetAgent.isStopped = false;
        }

        protected override void OnRun()
        {
            base.OnRun();

            controller.GetAgent.SetDestination(controller.GetTargetPosition);
        }

        protected override void OnExit()
        {
            base.OnExit();

            controller.GetAgent.isStopped = true;
        }
    }
}
