
using Core.Animals.Movement;
using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace Core.AI.Actions
{
    public class WanderAction : ActionTask<MovementController> {
        
        public float WanderRadius = 10f;

        private MovementController _movementController;

        protected override string OnInit()
        {
            _movementController = agent.GetComponent<MovementController>();
            return base.OnInit();
        }

        protected override void OnExecute()
        {
            Vector3 randomDirection = Random.insideUnitSphere * WanderRadius;
            randomDirection += agent.transform.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, WanderRadius, NavMesh.AllAreas);

            _movementController.SetTarget(hit.position);
            EndAction(true);
        }
    }
}