

using Core.Animals;
using Core.Player.Inputs;
using Core.State;
using UnityEngine;

namespace Core.Player
{
    public class PlayerControlsManager : MonoBehaviour
    {
        [SerializeField]
        private InputController _inputControl;

        private AnimalData _selectedAnimal;

        private float _lastClickTime;

        void Start()
        {
            _inputControl.OnClick += HandleClick;
            _selectedAnimal = AnimalDB.Instance.Animals[0];
        }

        private void HandleClick(Vector3 position)
        {
            if (Time.time - _lastClickTime < 0.5f)
            {
                return;
            }
            _lastClickTime = Time.time;
            AnimalManager.Instance.SpawnAnimal(_selectedAnimal, position);
        }

    }
}