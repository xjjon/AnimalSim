using Core.Animals;
using NodeCanvas.Framework;

namespace Core.AI.Actions
{
    public abstract class AnimalTask : ActionTask<AnimalComponent>
    {
        protected AnimalComponent AnimalComponent;

        protected override string OnInit()
        {
            AnimalComponent = agent.GetComponent<AnimalComponent>();
            return base.OnInit();
        }
    }
}