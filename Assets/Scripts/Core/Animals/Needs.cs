using UnityEngine;

namespace Core.Animals
{
    public class Needs : MonoBehaviour
    {
        [Header("Hunger System")]
        [Range(0f, 100f)]
        public float CurrentHunger = 100f;

        private AnimalComponent animalComponent;

        private void Awake()
        {
            animalComponent = GetComponent<AnimalComponent>();
        }

        public void Eat(float foodValue)
        {
            CurrentHunger = Mathf.Clamp(CurrentHunger - foodValue, 0f, 100f);
        }

        public bool IsHungry(float hungerThreshold)
        {
            return (CurrentHunger / 100f) >= hungerThreshold;
        }

        void Update()
        {
            CurrentHunger += animalComponent.Stats.HungerDecreaseRate * Time.deltaTime;

            if (CurrentHunger > 100f)
            {
                CurrentHunger = 100f;
            }
        }
    }
}
