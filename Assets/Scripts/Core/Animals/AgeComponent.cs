using UnityEngine;

namespace Core.Animals
{
    public class AgeComponent : MonoBehaviour
    {
        private static float TimePerYear = 20f;

        private AnimalComponent _animalComponent;

        private int _currentAge;
        private float _currentYearTimer;

        void Awake()
        {
            _animalComponent = GetComponent<AnimalComponent>();
        }
        private void Update()
        {
            _currentYearTimer += Time.deltaTime;
            if (_currentYearTimer >= TimePerYear)
            {
                _currentAge++;
                _currentYearTimer = 0f;
                if (_currentAge >= _animalComponent.AnimalData.MaxAge)
                {
                    Debug.Log($"{_animalComponent.AnimalData.AnimalName} has reached its maximum age of {_animalComponent.AnimalData.MaxAge} years and will be removed from the simulation.");
                    _animalComponent.Kill();
                }
            }
        }
    }
}