

using Core.Animals;
using NodeCanvas.Framework;

namespace Core.AI.Conditions
{
    public class HasMateCondition : AnimalCondition
    {
        [BlackboardOnly]
        public BBParameter<AnimalComponent> TargetAnimal;

        protected override bool OnCheck()
        {
            return TargetAnimal.value != null && TargetAnimal.value.ReproductionComponent.CanReproduce;
        }
    }
}