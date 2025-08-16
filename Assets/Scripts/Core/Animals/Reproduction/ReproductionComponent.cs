using Core.State;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Animals.Reproduction
{
    public class ReproductionComponent : MonoBehaviour
    {
        [SerializeField]
        private AnimalComponent _animalComponent;

        public Gender Gender { get; private set; }

        [Title("Debug"), SerializeField]
        private bool _setGender;
        [SerializeField]
        private Gender _debugGender;

        public bool CanReproduce => CurrentState == ReproductionState.Ready;
        public ReproductionState CurrentState { get; private set; } = ReproductionState.NotReady;

        private float _timer;

        private void Awake()
        {
            _animalComponent = GetComponent<AnimalComponent>();
            Gender = Random.value > 0.5f ? Gender.Male : Gender.Female;

            if (_setGender)
            {
                Gender = _debugGender;
            }
        }

        private void Start()
        {
            _animalComponent.AgeComponent.OnBecomeAdult += HandleBecomeAdult;
        }

        private void HandleBecomeAdult()
        {
            CurrentState = ReproductionState.Ready;
        }

        public bool StartPregnancy()
        {
            if (!CanReproduce) return false;
            CurrentState = ReproductionState.Pregnant;
            _timer = _animalComponent.AnimalData.Reproduction.PregnancyDuration;
            return true;
        }

        public void AttemptMate(ReproductionComponent mate)
        {
            if (CurrentState == ReproductionState.Ready || mate.Gender == Gender.Male)
            {
                return;
            }
            var status = mate.StartPregnancy();
            Debug.Log($"Attempting to mate with {mate.name}. Success: {status}");
        }

        void Update()
        {
            if (CurrentState == ReproductionState.Ready
            || CurrentState == ReproductionState.NotReady) return;
            _timer += Time.deltaTime;
            if (_timer > 0) return;
            switch (CurrentState)
            {
                case ReproductionState.Pregnant:
                    HandlePregnancyComplete();
                    break;
                case ReproductionState.PregnancyCooldown:
                    HandlePregnancyCooldownComplete();
                    break;
            }
        }

        private void HandlePregnancyComplete()
        {
            var childCount = _animalComponent.AnimalData.Reproduction.ChildCountRange.GetRandomValue();
            for (int i = 0; i < childCount; i++)
            {
                AnimalManager.Instance.SpawnAnimal(_animalComponent.AnimalData);
            }
        
            CurrentState = ReproductionState.Ready;
        }

        private void HandlePregnancyCooldownComplete()
        {
            CurrentState = ReproductionState.Ready;
            _timer = 0f;
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum ReproductionState
    {
        NotReady,
        Ready,
        Pregnant, // only used by females
        PregnancyCooldown, // only used by females
    }
}