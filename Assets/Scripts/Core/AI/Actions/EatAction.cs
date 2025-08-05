using Core.Animals;
using Core.Animation;
using Core.Food;
using NodeCanvas.Framework;
using UnityEngine;

namespace Core.AI.Actions
{
    public class EatAction : ActionTask
    {

        [BlackboardOnly]
        public BBParameter<FoodComponent> TargetFood;
        private AnimalComponent _animalComponent;

        private float _eatTime;

        protected override string OnInit()
        {
            _animalComponent = agent.GetComponent<AnimalComponent>();
            return base.OnInit();
        }

        protected override void OnExecute()
        {
            _eatTime = 0f;
            if (TargetFood.value != null)
            {
                _eatTime = TargetFood.value.ConsumeFood(_animalComponent);
                if (_eatTime <= 0f)
                {
                    EndAction(true);
                }
                
                _animalComponent.Animator.PlayState(AnimalState.Eat);
                return;
            }
            EndAction(false);
        }

        protected override void OnUpdate()
        {
            if (_eatTime > 0)
            {
                _eatTime -= Time.deltaTime;
                if (_eatTime <= 0)
                {
                    _animalComponent.Animator.PlayState(AnimalState.Idle);
                    EndAction(true);
                }
            }
        }
    }
}