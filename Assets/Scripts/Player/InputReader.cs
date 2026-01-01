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
        public Vector2 Move => moveAction.ReadValue<Vector2>();

        private void Start()
        {
            if(playerInput != null) moveAction = playerInput.actions["Move"];
            else
            {
                if (isLogging) Debug.Log($"{gameObject.name} has no playerInput");
            }
        }
    }
}