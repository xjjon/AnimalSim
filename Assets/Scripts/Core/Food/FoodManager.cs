using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Core.Food
{
    public class FoodManager : MonoSingleton<FoodManager>
    {
        private Dictionary<FoodType, List<FoodComponent>> _food = new Dictionary<FoodType, List<FoodComponent>>();

        public void FindFoodNearby(Vector3 position, float radius, FoodType type)
        {
            if (_food.TryGetValue(type, out var foodList))
            {
                foreach (var food in foodList)
                {
                    // sqr distance
                    if (Vector3.SqrMagnitude(food.transform.position - position) <= radius * radius)
                    {
                        // Do something with the food, e.g., add to a list of nearby food
                        Debug.Log($"Found {type} food at {food.transform.position}");
                    }
                }
            }
        }

        public void RegisterFood(FoodComponent foodComponent)
        {
            if (!_food.ContainsKey(foodComponent.Type))
            {
                _food[foodComponent.Type] = new List<FoodComponent>();
            }
            _food[foodComponent.Type].Add(foodComponent);
        }
    
    }
}