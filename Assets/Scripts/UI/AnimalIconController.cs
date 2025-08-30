using Core.Animals;
using UnityEngine.UIElements;

namespace UI
{
    public class AnimalIconController
    {
        private VisualElement _root;
        private VisualElement _icon;
        private Label _costLabel;

        public void SetVisualElement(VisualElement visualElement)
        {
            _root = visualElement;
            _icon = _root.Q<VisualElement>("Icon");
            _costLabel = _root.Q<Label>("Cost");
        }

        public void SetData(AnimalData animalData)
        {
            if (animalData.Icon != null)
            {
                _icon.style.backgroundImage = new StyleBackground(animalData.Icon);
            }

            _costLabel.text = $"{animalData.Cost}";
        }
    }
}
