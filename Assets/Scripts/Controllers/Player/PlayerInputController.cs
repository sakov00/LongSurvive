using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        private float horizontalInput;
        private float verticalInput;
        private float shootInput;

        public event Action<float, float> OnMovementEvent;
        public event Action<float> OnShootEvent;

        private bool controlsEnabled = true;

        private void FixedUpdate()
        {
            if (controlsEnabled)
            {
                OnMovementEvent?.Invoke(horizontalInput, verticalInput);
                OnShootEvent?.Invoke(shootInput);
            }
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

        public void EnableControls()
        {
            controlsEnabled = true;
        }

        public void DisableControls()
        {
            controlsEnabled = false;
        }
    }
}
