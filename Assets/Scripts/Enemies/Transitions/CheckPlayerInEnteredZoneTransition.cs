namespace Enemies.Transitions
{
    public class CheckPlayerInEnteredZoneTransition : CheckPlayerInZoneTransitionBase
    {
        public CheckPlayerInEnteredZoneTransition(string nextStateId)
        {
            NextStateId = nextStateId;
        }
        
        public override void Run(EnemyController controller)
        {
            Allowed = IsPlayerInRange(controller);
        }
    }
}
