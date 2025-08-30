using System.Collections.Generic;
using Core.Animals;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class AnimalToolbarController : MonoBehaviour
    {
        public UIDocument ToolbarDocument;
        public VisualTreeAsset AnimalIconAsset;

        private VisualElement _animalButtonsContainer;

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
                var animalIconController = new AnimalIconController();
                animalIcon.userData = animalIconController;
                animalIconController.SetVisualElement(animalIcon);
                animalIconController.SetData(animalData);

                _animalButtonsContainer.Add(animalIcon);
            }
        }
    }
}
