using UnityEngine;

namespace Shmup
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        bool isLogging = true;

        [SerializeField]
        float speed = 3f;
        [SerializeField]
        float smoothness = 0.1f;
        [SerializeField]
        float leanAngle = 15f;
        [SerializeField]
        float leanSpeed = 5f;

        [SerializeField]
        GameObject model;

        [Header("Camera Bounds")]
        [SerializeField]
        Transform CameraFollow;
        [SerializeField]
        float minX = -3f;
        [SerializeField]
        float maxX = 3f;
        [SerializeField]
        float minY = -3f;
        [SerializeField]
        float maxY = 3f;

        [SerializeField]
        InputReader input;

        Vector3 currentVelocity;
        Vector3 targetPosition;

        private void Start()
        {
            if (input == null)
            {
                if (isLogging) Debug.Log($"{gameObject.name} has no input");
            }
        }
        private void Update()
        {
            Move();
            Rotate();
        }
        private void Move()
        {
            targetPosition += new Vector3(input.Move.x, input.Move.y, transform.position.z) * (speed * Time.deltaTime);

            var minPlayerX = CameraFollow.position.x + minX;
            var maxPlayerX = CameraFollow.position.x + maxX;
            var minPlayerY = CameraFollow.position.y + minY;
            var maxPlayerY = CameraFollow.position.y + maxY;


            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);
        }
        private void Rotate()
        {
            var targetRotationAngle = -input.Move.x * leanAngle;

            var currentYRotation = transform.localEulerAngles.y;
            var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);

            transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);
        }
    }
}