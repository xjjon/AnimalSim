using Core.Animals;
using Core.Player.Currency;
using Core.Player.Inputs;
using Core.State;
using UI;
using UnityEngine;

namespace Core.Player
{
    public class PlayerControlsManager : MonoBehaviour
    {
        [SerializeField]
        private InputController _inputControl;

        [SerializeField]
        private AnimalToolbarController _toolbarController;

        private AnimalData _selectedAnimal;

        private float _lastClickTime;
        private CurrencyHolder _currencyHolder;

        void Start()
        {
            _inputControl.OnClick += HandleClick;
            _toolbarController.OnAnimalSelected += HandleAnimalSelected;
            _currencyHolder = GameManager.Instance.PlayerCurrency;
        }

        private void HandleAnimalSelected(AnimalData animalData)
        {
            _selectedAnimal = animalData;
        }

        private void HandleClick(Vector3 position)
        {
            if (_selectedAnimal == null) return;
            
            if (Time.time - _lastClickTime < 0.5f)
            {
                return;
            }
            if (!_currencyHolder.TrySpend(CurrencyType.Mana, _selectedAnimal.Cost))
            {
                return;
            }
            _lastClickTime = Time.time;
            AnimalManager.Instance.SpawnAnimal(_selectedAnimal, position);
        }

    }
}