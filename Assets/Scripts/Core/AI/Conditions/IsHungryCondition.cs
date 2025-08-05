
using Core.Animals;
using NodeCanvas.Framework;

namespace Core.AI.Conditions
{
    public class IsHungryCondition : ConditionTask
    {

        private AnimalComponent _animalComponent;

        protected override string OnInit()
        {
            _animalComponent = agent.GetComponent<AnimalComponent>();
            return base.OnInit();
        }

        protected override bool OnCheck()
        {
            return _animalComponent.Needs.IsHungry();
        }
    }
}