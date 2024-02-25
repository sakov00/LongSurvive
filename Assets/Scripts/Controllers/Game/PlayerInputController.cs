using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Controllers.Game
{
    public class PlayerInputController : MonoBehaviour
    {
        private float horizontalInput;
        private float verticalInput;
        private float shootInput;

        public event Action<float, float> OnMovementEvent;
        public event Action OnShootEvent;
        public event Action OnPauseMenuEvent;

        private void FixedUpdate()
        {
            OnMovementEvent?.Invoke(horizontalInput, verticalInput);

            if(shootInput == 1)
                OnShootEvent?.Invoke();
        }

        public void OnPauseMenu(InputAction.CallbackContext context)
        {
            if (context.canceled)
                OnPauseMenuEvent?.Invoke();
        }

        public void OnHorisontalMovement(InputAction.CallbackContext context)
        {
            horizontalInput = context.ReadValue<float>();
        }

        public void OnVerticalMovement(InputAction.CallbackContext context)
        {
            verticalInput = context.ReadValue<float>();
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            shootInput = context.ReadValue<float>();
        }
    }
}
