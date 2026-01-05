using UnityEngine;
using UnityEngine.InputSystem;
namespace Shmup
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        [SerializeField]
        bool isLogging = true;


        //NOTE:
        [SerializeField]
        PlayerInput playerInput;
        InputAction moveAction;
        InputAction fireAction;
        public Vector2 Move => moveAction.ReadValue<Vector2>();
        public bool Fire => fireAction.ReadValue<float>() > 0f;

        private void Start()
        {
            if (playerInput != null)
            {
                moveAction = playerInput.actions["Move"];
                fireAction = playerInput.actions["Attack"];
            }
            else
            {
                if (isLogging) Debug.Log($"{gameObject.name} has no playerInput");
            }
        }
    }
}