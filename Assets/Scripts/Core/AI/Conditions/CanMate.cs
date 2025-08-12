

namespace Core.AI.Conditions
{
    public class CanMate : AnimalCondition
    {
        protected override bool OnCheck()
        {
            if (AnimalComponent.ReproductionComponent.Gender == Animals.Reproduction.Gender.Female)
            {
                return false;
            }
            return AnimalComponent.ReproductionComponent.CanReproduce;
        }
    }
}