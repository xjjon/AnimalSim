using UnityEngine;
using UnityEngine.AI;

namespace Core.Animals.Movement
{
    public class MovementController : MonoBehaviour
    {
        private AnimalComponent animalComponent;

        private float _moveSpeed;
        private float _runSpeed;

    private NavMeshAgent navMeshAgent;

        private void Awake()
        {
            animalComponent = GetComponent<AnimalComponent>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (animalComponent != null && animalComponent.Stats != null)
            {
                _moveSpeed = animalComponent.Stats.MoveSpeed;
                _runSpeed = animalComponent.Stats.RunSpeed;
            }
            navMeshAgent.speed = _moveSpeed;
        }

        public void SetTarget(Vector3 targetPosition)
        {
            navMeshAgent.SetDestination(targetPosition);
        }

    }
}