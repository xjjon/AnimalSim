using System;
using AnimalSim.Assets.Scripts.Core.Animals;
using Core.Animals.Movement;
using Core.Animation;
using NodeCanvas.StateMachines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Animals
{
    public class AnimalComponent : MonoBehaviour
    {
        [NonSerialized]
        public Action OnAnimalDeath;

        [AssetSelector]
        public AnimalData AnimalData;
        
        [Title("Components")]
        public Needs Needs;
        public MovementController Movement;

        public AnimatorController Animator;
        
        public FSMOwner StateMachine;

        public void Kill()
        {
            OnAnimalDeath?.Invoke();
            StateMachine.StopBehaviour();
            Movement.StopMovement();
            Animator.PlayState(AnimalState.Die);
            Destroy(gameObject, 5f);
        }
    }
}