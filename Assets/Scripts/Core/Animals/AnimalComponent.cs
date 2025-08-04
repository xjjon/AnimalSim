using Sirenix.OdinInspector;
using UnityEngine;

namespace AnimalSim.Assets.Scripts.Core.Animals
{
    public class AnimalComponent : MonoBehaviour
    {
        [AssetSelector]
        public AnimalStats Stats;
        [Title("Components")]
        public Needs Needs;
    }
}