using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Core.Player.Inputs
{

    public class InputController : MonoBehaviour
    {
        [NonSerialized]
        public Action<Vector3> OnClick;

        [SerializeField]
        private Camera _camera;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                
                OnClick?.Invoke(GetGroundPosition(Input.mousePosition));
            }
        }

        private Vector3 GetGroundPosition(Vector3 screenPosition)
        {
            Ray ray = _camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return hit.point;
            }
            return Vector3.zero;
        }
    }
}