using Core.Food;
using UnityEngine;

namespace Core.Animals
{
    public class Needs : MonoBehaviour
    {
        [Header("Hunger System")]
        [Range(0f, 100f)]
        public float CurrentHunger = 0;

        public FoodType FoodType;

        private AnimalComponent _animalComponent;
        private float _hungerThreshold;

        private bool _enabled;

        private void Awake()
        {
            _animalComponent = GetComponent<AnimalComponent>();
            _hungerThreshold = _animalComponent.Stats.HungerThreshold;
            _enabled = true;
        }

        public void Eat(float foodValue)
        {
            CurrentHunger = Mathf.Clamp(CurrentHunger - foodValue, 0f, 100f);
        }

        public bool IsHungry()
        {
            return (CurrentHunger / 100f) >= _hungerThreshold;
        }

        void Update()
        {
            if (!_enabled) return;
            CurrentHunger += _animalComponent.Stats.HungerDecreaseRate * Time.deltaTime;

            if (CurrentHunger > 100f)
            {
                CurrentHunger = 100f;
                _animalComponent.Kill();
                _enabled = false;
            }
        }
    }
}
