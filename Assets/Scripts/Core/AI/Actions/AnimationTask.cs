using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Animation;
using NodeCanvas.Framework;

namespace AnimalSim.Assets.Scripts.Core.AI.Actions
{
    public class AnimationTask : ActionTask
    {
        public AnimalState AnimationState;
        private AnimatorController _animator;

        protected override string OnInit()
        {
            _animator = agent.GetComponent<AnimatorController>();
            return base.OnInit();
        }

        protected override void OnExecute()
        {
            _animator.PlayState(AnimationState);
            EndAction(true);
        }
    }
}