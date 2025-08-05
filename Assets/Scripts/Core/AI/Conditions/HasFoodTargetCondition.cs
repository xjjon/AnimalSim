using Core.Food;
using NodeCanvas.Framework;

namespace Core.AI.Conditions
{
    public class HasFoodTargetCondition : ConditionTask
    {
        [BlackboardOnly]
        public BBParameter<FoodComponent> TargetFood;

        protected override string OnInit()
        {
            return base.OnInit();
        }

        protected override bool OnCheck()
        {
            return TargetFood.value != null;
        }
    }
}