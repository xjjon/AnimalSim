using Core.Animation;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Animals.Movement
{
    public class MovementController : MonoBehaviour
    {
        private AnimalComponent animalComponent;

        private Rigidbody _rigidbody;

        private float _moveSpeed;
        private float _runSpeed;

        private NavMeshAgent navMeshAgent;

        private void Awake()
        {
            animalComponent = GetComponent<AnimalComponent>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            _rigidbody = GetComponent<Rigidbody>();
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
            animalComponent.Animator.PlayState(AnimalState.Walk);
        }
        
        public void StopMovement()
        {
            navMeshAgent.ResetPath();
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;

            animalComponent.Animator.PlayState(AnimalState.Idle);
        }

    }
}