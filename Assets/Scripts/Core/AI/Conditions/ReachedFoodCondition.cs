
using Core.Food;
using NodeCanvas.Framework;
using UnityEngine;

namespace Core.AI.Conditions
{
    public class ReachedFoodCondition : ConditionTask
    {
        [BlackboardOnly]
        public BBParameter<FoodComponent> TargetFood;

        protected override string OnInit()
        {
            return base.OnInit();
        }

        protected override bool OnCheck()
        {
            if (TargetFood.value == null)
            {
                return false;
            }
            return (agent.transform.position - TargetFood.value.transform.position).sqrMagnitude < 1f * 1f;
        }
    }
}