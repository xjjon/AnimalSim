
using Core.Animals;

namespace Core.AI.Conditions
{
    public class IsHungryCondition : AnimalCondition
    {
        protected override bool OnCheck()
        {
            return AnimalComponent.Needs.IsHungry();
        }
    }
}