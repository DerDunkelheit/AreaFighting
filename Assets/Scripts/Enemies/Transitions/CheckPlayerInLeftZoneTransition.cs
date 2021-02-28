namespace Enemies.Transitions
{
    public class CheckPlayerInLeftZoneTransition : CheckPlayerInZoneTransitionBase
    {
        public CheckPlayerInLeftZoneTransition(string nextStateId)
        {
            NextStateId = nextStateId;
        }
        
        public override void Run(EnemyController controller)
        {
            Allowed = !IsPlayerInRange(controller);
        }
    }
}
