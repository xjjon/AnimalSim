using UnityEngine;
using Animancer;
using Core.Animals;

namespace Core.Animation
{
    public class AnimatorController : MonoBehaviour
    {
        [SerializeField]
        private AnimationData animationData;

        private AnimancerComponent animancer;

        private void Awake()
        {
            animancer = GetComponentInChildren<AnimancerComponent>();
            PlayState(AnimalState.Idle);
        }

        public void PlayState(AnimalState state)
        {
            if (animationData.StateClips.TryGetValue(state, out var clip) && clip != null)
            {
                animancer.Play(clip, 0.2f);
            }
        }
    }
}