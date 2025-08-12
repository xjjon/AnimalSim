using Core.Animals;
using Core.Animation;
using Core.Food;
using NodeCanvas.Framework;
using UnityEngine;

namespace Core.AI.Actions
{
    public class EatAction : AnimalTask
    {

        [BlackboardOnly]
        public BBParameter<FoodComponent> TargetFood;

        private float _eatTime;

        protected override void OnExecute()
        {
            _eatTime = 0f;
            if (TargetFood.value != null)
            {
                _eatTime = TargetFood.value.ConsumeFood(AnimalComponent);
                if (_eatTime <= 0f)
                {
                    EndAction(true);
                }

                AnimalComponent.Animator.PlayState(AnimalState.Eat);
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
                    AnimalComponent.Animator.PlayState(AnimalState.Idle);
                    EndAction(true);
                }
            }
        }
    }
}