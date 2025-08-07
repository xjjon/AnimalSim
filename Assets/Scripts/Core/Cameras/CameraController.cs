using UnityEngine;

namespace Core.Cameras
{
    public class CameraController : MonoBehaviour
    {
        public float moveSpeed = 5f;

        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Make movement relative to camera's Y rotation
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 desiredMove = forward * moveZ + right * moveX;
            desiredMove *= moveSpeed * Time.deltaTime;

            transform.Translate(desiredMove, Space.World);
        }
    }
}