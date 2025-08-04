using UnityEngine;

namespace Core.Animals
{

    [CreateAssetMenu(fileName = "New Animal Stats", menuName = "Animal Stats")]
    public class AnimalStats : ScriptableObject
    {
        [Header("Movement")]
        public float MoveSpeed = 3f;
        public float RunSpeed = 6f;

        [Header("Senses")]
        public float SightRadius = 5f;

        [Header("Survival")]
        public float HungerThreshold = 0.3f;
        public float HungerDecreaseRate = 0.1f; // Rate at which hunger decreases over time
    }
}