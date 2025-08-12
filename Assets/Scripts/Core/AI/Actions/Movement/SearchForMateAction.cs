
using Core.Animals;
using Core.State;
using NodeCanvas.Framework;

namespace Core.AI.Actions.Movement
{
    // Action to search for mate within radius. Should only execute for male animals.
    // Will repeat tracking until interrupted
    public class SearchForMateAction : TrackingMovementAction
    {
        public float SearchRadius = 10f;

        [BlackboardOnly]
        public BBParameter<AnimalComponent> TargetMate;

        private AnimalComponent _animalComponent;

        protected override string OnInit()
        {
            _animalComponent = agent.GetComponent<AnimalComponent>();
            return base.OnInit();
        }

        protected override void OnExecute()
        {
            var potentialMates = AnimalManager.Instance.GetAdultFemales(_animalComponent.AnimalData);
            float searchRadiusSqr = SearchRadius * SearchRadius;
            foreach (var mate in potentialMates)
            {
                if ((_animalComponent.transform.position - mate.transform.position).sqrMagnitude <= searchRadiusSqr)
                {
                    TargetMate.value = mate;
                    SetTarget(mate.transform);
                    break;
                }
            }
        }
    }
}