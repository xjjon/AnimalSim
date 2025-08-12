using Core.Animals;
using Core.Food;
using NodeCanvas.Framework;
using UnityEngine;

namespace Core.AI.Actions
{
    public class SearchForFoodAction : AnimalTask
    {
        public float SearchRadius = 10f;
        [BlackboardOnly]
        public BBParameter<FoodComponent> TargetFood;

        protected override void OnExecute()
        {
            // Find the nearest food using the FoodManager
            var food = FoodManager.Instance.FindFoodNearby(agent.transform.position, SearchRadius, AnimalComponent.Needs.FoodType);
            if (food != null)
            {
                AnimalComponent.Movement.SetTarget(food.transform.position);
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