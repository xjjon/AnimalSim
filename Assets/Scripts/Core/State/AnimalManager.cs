using System.Collections.Generic;
using Core.Animals;
using Core.Animals.Reproduction;
using UnityEngine;
using Util;

namespace Core.State
{
    public class AnimalManager : MonoSingleton<AnimalManager>
    {
        private readonly List<AnimalComponent> _animals = new List<AnimalComponent>();

    // Fast lookup indexes
    private readonly Dictionary<AnimalData, HashSet<AnimalComponent>> _animalsByData = new Dictionary<AnimalData, HashSet<AnimalComponent>>();
    // Cache of adult females keyed by AnimalData
    private readonly Dictionary<AnimalData, HashSet<AnimalComponent>> _adultFemalesByData = new Dictionary<AnimalData, HashSet<AnimalComponent>>();

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
                IndexAnimal(animal);
            }
        }

        public void UnregisterAnimal(AnimalComponent animal)
        {
            if (_animals.Contains(animal))
            {
                _animals.Remove(animal);
                UnindexAnimal(animal);
            }
        }

        public List<AnimalComponent> GetAllAnimals()
        {
            return new List<AnimalComponent>(_animals);
        }

        public HashSet<AnimalComponent> GetAnimalsByData(AnimalData data)
        {
            if (_animalsByData.TryGetValue(data, out var set))
            {
                return set;
            }
            return null;
        }

        public HashSet<AnimalComponent> GetAdultFemales(AnimalData data)
        {
            if (data == null) return new HashSet<AnimalComponent>();
            return _adultFemalesByData.TryGetValue(data, out var set) ? set : new HashSet<AnimalComponent>();
        }

        public int CountAdultFemalesByData(AnimalData data)
        {
            return data != null && _adultFemalesByData.TryGetValue(data, out var set) ? set.Count : 0;
        }

        private void IndexAnimal(AnimalComponent animal)
        {
            var data = animal.AnimalData;
            if (!_animalsByData.TryGetValue(data, out var setByData))
            {
                setByData = new HashSet<AnimalComponent>();
                _animalsByData[data] = setByData;
            }
            setByData.Add(animal);

            TryAddAdultFemale(animal);

            // If not adult yet, subscribe to adult transition to populate later
            if (animal.ReproductionComponent.Gender == Gender.Female)
            {
                animal.AgeComponent.OnBecomeAdult += () => TryAddAdultFemale(animal);
            }

            animal.OnAnimalDeath += () => UnregisterAnimal(animal);
        }

        private void UnindexAnimal(AnimalComponent animal)
        {
            var data = animal.AnimalData;
            if (_animalsByData.TryGetValue(data, out var setByData))
            {
                setByData.Remove(animal);
                if (setByData.Count == 0)
                {
                    _animalsByData.Remove(data);
                }
            }

            if (data != null && _adultFemalesByData.TryGetValue(data, out var adultSet))
            {
                adultSet.Remove(animal);
                if (adultSet.Count == 0)
                {
                    _adultFemalesByData.Remove(data);
                }
            }
        }

        private void TryAddAdultFemale(AnimalComponent animal)
        {
            var isFemale = animal.ReproductionComponent.Gender == Gender.Female;
            var isAdult = animal.AgeComponent.IsAdult;
            if (!(isFemale && isAdult)) return;

            if (!_adultFemalesByData.TryGetValue(animal.AnimalData, out var set))
            {
                set = new HashSet<AnimalComponent>();
                _adultFemalesByData[animal.AnimalData] = set;
            }
            set.Add(animal);
        }
    }
}