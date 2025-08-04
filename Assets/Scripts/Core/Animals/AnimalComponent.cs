using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Animals
{
    public class AnimalComponent : MonoBehaviour
    {
        [AssetSelector]
        public AnimalStats Stats;
        [Title("Components")]
        public Needs Needs;
    }
}