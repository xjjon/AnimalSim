using System.Collections.Generic;
using Core.Animals;
using UnityEngine;
using Util;

namespace Core.State
{
    public class AnimalManager : MonoSingleton<AnimalManager>
    {
        private List<AnimalComponent> _animals = new List<AnimalComponent>();

        void Start()
        {
            foreach (var animal in FindObjectsByType<AnimalComponent>(FindObjectsSortMode.None))
            {
                RegisterAnimal(animal);
            }
        }

        public AnimalComponent SpawnAnimal(AnimalData animalData)
        {
            var animal = Instantiate(animalData.Prefab, Vector3.zero, Quaternion.identity);
            RegisterAnimal(animal);
            return animal;
        }

        public void RegisterAnimal(AnimalComponent animal)
        {
            if (!_animals.Contains(animal))
            {
                _animals.Add(animal);
            }
        }

        public void UnregisterAnimal(AnimalComponent animal)
        {
            if (_animals.Contains(animal))
            {
                _animals.Remove(animal);
            }
        }

        public List<AnimalComponent> GetAllAnimals()
        {
            return new List<AnimalComponent>(_animals);
        }
    }
}