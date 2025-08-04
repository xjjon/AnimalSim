using System;
using Core.Animals;
using UnityEngine;

namespace Core.Food
{
    public class FoodComponent : MonoBehaviour
    {
        public Action OnFoodConsumed;
        public FoodType Type;
        public float EnergyValue;

        public void ConsumeFood(AnimalComponent animal)
        {
            animal.Needs.Eat(EnergyValue);
            OnFoodConsumed?.Invoke();
            Destroy(gameObject);
        }
    }
}