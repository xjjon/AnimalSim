using Core.Animals;
using NodeCanvas.Framework;

namespace Core.AI.Conditions
{
    public class ReachedMateCondition : ConditionTask
    {
        [BlackboardOnly]
        public BBParameter<AnimalComponent> TargetAnimal;

        protected override bool OnCheck()
        {
            if (TargetAnimal.value == null)
            {
                return false;
            }
            return (agent.transform.position - TargetAnimal.value.transform.position).sqrMagnitude < 1.5f * 1.5f;
        }
    }
}