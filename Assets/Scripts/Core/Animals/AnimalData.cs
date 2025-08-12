using Sirenix.OdinInspector;
using UnityEngine;
using Core.Animals.Reproduction;

namespace Core.Animals
{
    [CreateAssetMenu(fileName = "New Animal", menuName = "Animals/Animal Data")]
    public class AnimalData : SerializedScriptableObject
    {
        [Required]
        public string AnimalName;

        [Title("Prefab")]
        [Required, AssetSelector(Paths = "Assets/Prefabs/Animals")]
        public AnimalComponent Prefab;

        [Title("Stats")]
        [Required, AssetSelector, InlineEditor(InlineEditorObjectFieldModes.Foldout)]
        public AnimalStats Stats;

        public int MaxAge;

        public int AdultAge;

        public ReproductionStats Reproduction = new ReproductionStats();
    }
}