using UnityEngine;

namespace Core.Animals
{
    public class Needs : MonoBehaviour
    {
        [Header("Hunger System")]
        [SerializeField, Range(0f, 100f)]
        public float currentHunger = 0f;

        private AnimalComponent animalComponent;

        private void Awake()
        {
            animalComponent = GetComponent<AnimalComponent>();
        }

        public void Eat(float foodValue)
        {
            currentHunger = Mathf.Clamp(currentHunger - foodValue, 0f, 100f);
        }

        public bool IsHungry(float hungerThreshold)
        {
            return (currentHunger / 100f) >= hungerThreshold;
        }

        void Update()
        {
            if (animalComponent != null && animalComponent.Stats != null)
            {
                currentHunger += animalComponent.Stats.HungerDecreaseRate * Time.deltaTime;

                if (currentHunger > 100f)
                {
                    currentHunger = 100f;
                }
            }
        }
    }
}
