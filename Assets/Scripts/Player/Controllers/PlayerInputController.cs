using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerInputController : MonoBehaviour
    {
        private Vector3 movementInput;
        private float shootInput;

        public event Action OnPauseMenuEvent;
        public event Action<Vector3> OnMovementEvent;
        public event Action OnJumpEvent;
        public event Action<float> OnScrollEvent;
        public event Action OnShootEvent;
        public event Action OnInteractEvent;

        private void Update()
        {
            OnMovementEvent?.Invoke(movementInput);

            if (shootInput == 1)
                OnShootEvent?.Invoke();
        }

        public void OnPauseMenu(InputAction.CallbackContext context)
        {
            if (context.started)
                OnPauseMenuEvent?.Invoke();
        }

        public void OnHorizontalMovement(InputAction.CallbackContext context)
        {
            movementInput.x = context.ReadValue<float>();
        }

        public void OnVerticalMovement(InputAction.CallbackContext context)
        {
            movementInput.z = context.ReadValue<float>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
                OnJumpEvent.Invoke();
        }

        public void OnScroll(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                var scrollValue = context.ReadValue<float>();
                if (scrollValue >= 1)
                    scrollValue = 1;
                if (scrollValue <= -1)
                    scrollValue = -1;
                OnScrollEvent.Invoke(scrollValue);
            }
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            shootInput = context.ReadValue<float>();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
                OnInteractEvent?.Invoke();
        }
    }
}
