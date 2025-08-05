using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Core.Food
{
    public class FoodManager : MonoSingleton<FoodManager>
    {
        private Dictionary<FoodType, List<FoodComponent>> _food = new Dictionary<FoodType, List<FoodComponent>>();

        public FoodComponent FindFoodNearby(Vector3 position, float radius, FoodType type)
        {
            if (_food.TryGetValue(type, out var foodList))
            {
                foreach (var food in foodList)
                {
                    // sqr distance
                    if (Vector3.SqrMagnitude(food.transform.position - position) <= radius * radius)
                    {
                        return food;
                    }
                }
            }
            return null;
        }

        public void RegisterFood(FoodComponent foodComponent)
        {
            if (!_food.ContainsKey(foodComponent.Type))
            {
                _food[foodComponent.Type] = new List<FoodComponent>();
            }
            _food[foodComponent.Type].Add(foodComponent);
            foodComponent.OnFoodConsumed += () => UnregisterFood(foodComponent);
        }

        private void UnregisterFood(FoodComponent foodComponent)
        {
            if (_food.ContainsKey(foodComponent.Type))
            {
                _food[foodComponent.Type].Remove(foodComponent);
            }
        }

    }
}