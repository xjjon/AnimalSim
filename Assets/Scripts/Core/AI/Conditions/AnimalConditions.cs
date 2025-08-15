using Core.Animals;
using NodeCanvas.Framework;

namespace Core.AI.Conditions
{
    public abstract class AnimalCondition : ConditionTask
    {
        protected AnimalComponent AnimalComponent;

        protected override string OnInit()
        {
            AnimalComponent = agent.GetComponent<AnimalComponent>();
            return base.OnInit();
        }
    }
}