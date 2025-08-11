using UnityEngine;

namespace Core.Animals.Reproduction
{
    public class ReproductionComponent : MonoBehaviour
    {
        [SerializeField]
        private AnimalComponent _animalComponent;

        public Gender Gender { get; private set; }

        private bool _canReproduce;

        private float _timeUntilNextReproduction;

        private void Awake()
        {
            _animalComponent = GetComponent<AnimalComponent>();
            Gender = Random.value > 0.5f ? Gender.Male : Gender.Female;
        }

        private void Start()
        {
            _animalComponent.AgeComponent.OnBecomeAdult += HandleBecomeAdult;
        }

        private void HandleBecomeAdult()
        {
            _canReproduce = true;
            // TODO: Implement reproduction logic and stats
        }

    }

    public enum Gender
    {
        Male,
        Female
    }
}