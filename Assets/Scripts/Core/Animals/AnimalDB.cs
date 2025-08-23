
using System.Collections.Generic;
using Util;

namespace Core.Animals
{
    public class AnimalDB : MonoSingleton<AnimalDB>
    {
        public List<AnimalData> Animals = new List<AnimalData>();

        private Dictionary<string, AnimalData> _animalDict;

        protected override void Awake()
        {
            base.Awake();
            InitializeAnimalDictionary();
        }

        private void InitializeAnimalDictionary()
        {
            _animalDict = new Dictionary<string, AnimalData>();
            foreach (var animal in Animals)
            {
                _animalDict[animal.AnimalName] = animal;
            }
        }

        public AnimalData GetAnimalData(string name)
        {
            _animalDict.TryGetValue(name, out var animalData);
            return animalData;
        }
    }
}