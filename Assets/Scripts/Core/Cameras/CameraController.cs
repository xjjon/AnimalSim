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

            // Camera rotation with Q and E
            float rotateY = 0f;
            if (Input.GetKey(KeyCode.Q))
            rotateY = -1f;
            else if (Input.GetKey(KeyCode.E))
            rotateY = 1f;

            if (rotateY != 0f)
            {
            float rotationSpeed = 100f;
            transform.Rotate(0f, rotateY * rotationSpeed * Time.deltaTime, 0f, Space.World);
            }

            float zoomInput = 0f;
            if (Input.GetKey(KeyCode.F))
                zoomInput = -1f;
            else if (Input.GetKey(KeyCode.R))
                zoomInput = 1f;

            if (zoomInput != 0f)
            {
                float zoomSpeed = 10f;
                float newY = Mathf.Clamp(transform.position.y + zoomInput * zoomSpeed * Time.deltaTime, 15f, 30f);
                Vector3 pos = transform.position;
                pos.y = newY;
                transform.position = pos;
            }

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