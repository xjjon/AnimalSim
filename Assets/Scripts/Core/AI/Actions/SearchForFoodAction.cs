using Core.Animals;
using Core.Food;
using NodeCanvas.Framework;
using UnityEngine;

namespace Core.AI.Actions
{
    public class SearchForFoodAction : ActionTask
    {
        public float SearchRadius = 10f;
        [BlackboardOnly]
        public BBParameter<FoodComponent> TargetFood;

        private AnimalComponent _animalComponent;

        protected override string OnInit()
        {
            _animalComponent = agent.GetComponent<AnimalComponent>();
            return base.OnInit();
        }

        protected override void OnExecute()
        {
            // Find the nearest food using the FoodManager
            var food = FoodManager.Instance.FindFoodNearby(agent.transform.position, SearchRadius, _animalComponent.Needs.FoodType);
            if (food != null)
            {
                _animalComponent.Movement.SetTarget(food.transform.position);
                TargetFood.value = food;
                EndAction(true);
                return;
            }
            else
            {
                EndAction(false);
            }
        }
    }
}