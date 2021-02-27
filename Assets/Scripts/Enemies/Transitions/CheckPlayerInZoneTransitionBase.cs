using UnityEngine;

namespace Enemies.Transitions
{
    public abstract class CheckPlayerInZoneTransitionBase : ITransition
    {
        public  bool Allowed { get; protected set; }
        public string NextStateId { get; protected set; }
        public abstract void Run(EnemyController controller);

        protected bool IsPlayerInRange(EnemyController controller)
        {
            return Vector2.Distance(controller.gameObject.transform.position, controller.GetTargetPosition) <=
                   controller.GetDetectRange;
        }
    }
}
