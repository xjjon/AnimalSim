using System.Collections.Generic;
using Core.Food;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AnimalSim.Assets.Scripts.Core.Food
{
    public class FoodSpawner : MonoBehaviour
    {
        [AssetSelector]
        public FoodComponent FoodPrefab;
        public float SpawnRadius = 5f;

        public int MaxFoodCount = 10;
        public int InitialFoodCount = 5;

        public float RespawnInterval = 20f;

        private float _respawnTimer = 0f;


        private List<FoodComponent> _spawnedFood = new List<FoodComponent>();

        void Start()
        {
            for (int i = 0; i < InitialFoodCount && _spawnedFood.Count < MaxFoodCount; i++)
            {
                SpawnFood();
            }
        }

        void Update()
        {
            if (_spawnedFood.Count < MaxFoodCount)
            {
                _respawnTimer += Time.deltaTime;
                if (_respawnTimer >= RespawnInterval)
                {
                    SpawnFood();
                    _respawnTimer = 0f;
                }
            }
        }

        private void SpawnFood()
        {
            if (_spawnedFood.Count >= MaxFoodCount)
                return;

            Vector2 randomCircle = Random.insideUnitCircle * SpawnRadius;
            Vector3 spawnPosition = transform.position + new Vector3(randomCircle.x, 0f, randomCircle.y);

            spawnPosition.y = Util.RaycastUtils.GetGroundHeight(spawnPosition);

            FoodComponent food = Instantiate(FoodPrefab, spawnPosition, Quaternion.identity);
            food.OnFoodConsumed += () =>
            {
                _spawnedFood.Remove(food);
            };
            _spawnedFood.Add(food);
            FoodManager.Instance.RegisterFood(food);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, SpawnRadius);
        }

        private void OnDrawGizmos()
        {
            string label = FoodPrefab != null ? FoodPrefab.name : "Food Spawner";
            var style = new GUIStyle(UnityEditor.EditorStyles.boldLabel)
            {
                fontSize = 14,
                normal = { textColor = Color.yellow }
            };
            UnityEditor.Handles.Label(transform.position + Vector3.up * 1.5f, label, style);
        }

    }
}