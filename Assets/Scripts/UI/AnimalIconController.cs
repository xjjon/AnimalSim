using Core.Animals;
using UnityEngine.UIElements;

namespace UI
{
    public class AnimalIconController
    {
        private VisualElement _root;
        private VisualElement _icon;
        private Label _costLabel;
        private AnimalData _animalData;
        private bool _isSelected;

        private readonly AnimalToolbarController _toolbarController;

        public AnimalData AnimalData => _animalData;
        public bool IsSelected => _isSelected;

        public AnimalIconController(AnimalToolbarController toolbarController = null)
        {
            _toolbarController = toolbarController;
        }

        public void SetVisualElement(VisualElement visualElement)
        {
            _root = visualElement.Q(className: "animal-icon-root");
            _icon = _root.Q<VisualElement>("Icon");
            _costLabel = _root.Q<Label>("Cost");

            _root.RegisterCallback<ClickEvent>(OnIconClicked);
        }
        public void SetData(AnimalData animalData)
        {
            if (animalData.Icon != null)
            {
                _icon.style.backgroundImage = new StyleBackground(animalData.Icon);
            }

            _costLabel.text = $"{animalData.Cost}";
            _animalData = animalData;
        }

        public void SetSelected(bool selected)
        {
            _isSelected = selected;
            UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            _root.EnableInClassList("selected", _isSelected);
        }

        private void OnIconClicked(ClickEvent evt)
        {
            _toolbarController?.OnIconSelected(this);
        }
    }
}
