

using Core.Animals;
using NodeCanvas.Framework;

namespace Core.AI.Actions
{
    public class MateTask : AnimalTask
    {
        [BlackboardOnly]
        public BBParameter<AnimalComponent> TargetAnimal;
         
        protected override void OnExecute()
        {
            if (TargetAnimal.value == null || !AnimalComponent.ReproductionComponent.CanReproduce)
            {
                EndAction(false);
                return;
            }

            AnimalComponent.ReproductionComponent.AttemptMate(TargetAnimal.value.ReproductionComponent);
            TargetAnimal.value = null;
            EndAction(true);
        }
    }
}