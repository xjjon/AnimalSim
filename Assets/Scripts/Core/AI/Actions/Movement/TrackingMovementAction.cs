
using UnityEngine;

namespace Core.AI.Actions.Movement
{
    public class TrackingMovementAction : AnimalTask
    {
        protected Transform Target;
        private const float UpdateInterval = 0.2f;
        private float _timeSinceLastUpdate;

        protected void SetTarget(Transform target)
        {
            Target = target;
        }

        protected override void OnUpdate()
        {
            if (Target == null)
            {
                EndAction(false);
                return;
            }

            _timeSinceLastUpdate += Time.deltaTime;
            if (_timeSinceLastUpdate >= UpdateInterval)
            {
                AnimalComponent.Movement.SetTarget(Target.position);
                _timeSinceLastUpdate = 0f;
            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            AnimalComponent.Movement.StopMovement();
            _timeSinceLastUpdate = 0f;
            Target = null;
        }
    }
}