using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        bool isLogging = true;

        [SerializeField]
        Transform player;
        [SerializeField]
        private float speed = 1.5f;

        private void Start()
        {
            if (player == null)
            {
                if (isLogging) Debug.Log($"{gameObject.name} has no player");
            }
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        private void LateUpdate()
        {
            MoveCamera();
        }
        private void MoveCamera()
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}