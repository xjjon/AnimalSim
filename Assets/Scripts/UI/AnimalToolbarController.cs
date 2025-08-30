using System;
using System.Collections.Generic;
using Core.Animals;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class AnimalToolbarController : MonoBehaviour
    {
        public event Action<AnimalData> OnAnimalSelected;
        public UIDocument ToolbarDocument;
        public VisualTreeAsset AnimalIconAsset;

        private VisualElement _animalButtonsContainer;

        private List<AnimalIconController> _animalIconControllers = new List<AnimalIconController>();
        private AnimalIconController _selectedIcon;

        public AnimalIconController SelectedIcon => _selectedIcon;

        private void Start()
        {
            var root = ToolbarDocument.rootVisualElement;
            _animalButtonsContainer = root.Q<VisualElement>("AnimalButtons");

            PopulateToolbar();
        }

        private void PopulateToolbar()
        {
            var animalDB = AnimalDB.Instance;
            if (animalDB == null || animalDB.Animals == null)
            {
                Debug.LogError("AnimalDB not found or has no animals.");
                return;
            }

            foreach (var animalData in animalDB.Animals)
            {
                var animalIcon = AnimalIconAsset.CloneTree();
                var animalIconController = new AnimalIconController(this);
                animalIcon.userData = animalIconController;
                animalIconController.SetVisualElement(animalIcon);
                animalIconController.SetData(animalData);

                _animalButtonsContainer.Add(animalIcon);
                _animalIconControllers.Add(animalIconController);
            }
        }

        public void OnIconSelected(AnimalIconController selectedIcon)
        {
            if (_selectedIcon == selectedIcon)
            {
                _selectedIcon.SetSelected(false);
                _selectedIcon = null;
            }
            else
            {
                if (_selectedIcon != null)
                {
                    _selectedIcon.SetSelected(false);
                }
                
                _selectedIcon = selectedIcon;
                _selectedIcon.SetSelected(true);
            }

            OnAnimalSelected?.Invoke(_selectedIcon?.AnimalData);
        }
    }
}
