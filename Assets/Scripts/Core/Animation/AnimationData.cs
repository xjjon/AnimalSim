
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Core.Animation
{
    [CreateAssetMenu(fileName = "AnimationData", menuName = "Animation Data")]
    public class AnimationData : SerializedScriptableObject
    {
        [DictionaryDrawerSettings(KeyLabel = "State", ValueLabel = "Clip")]
        public Dictionary<AnimalState, AnimationClip> StateClips = new Dictionary<AnimalState, AnimationClip>
         {
            { AnimalState.Idle, null },
            { AnimalState.Walk, null },
            { AnimalState.Eat, null },
            { AnimalState.Die, null }
         };
    }
}