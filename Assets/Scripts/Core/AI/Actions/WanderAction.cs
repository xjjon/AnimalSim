
using Core.Animals.Movement;
using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace Core.AI.Actions
{
    public class WanderAction : ActionTask<MovementController> {
        
        public float WanderRadius = 10f;

        private NavMeshAgent _navMeshAgent;

        protected override string OnInit()
        {
            _navMeshAgent = agent.GetComponent<NavMeshAgent>();
            return base.OnInit();
        }

        protected override void OnExecute()
        {
            Vector3 randomDirection = Random.insideUnitSphere * WanderRadius;
            randomDirection += agent.transform.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, WanderRadius, NavMesh.AllAreas);

            _navMeshAgent.SetDestination(hit.position);
            EndAction(true);
        }
    }
}