using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private CameraController cameraController;
        [Inject] private PlayerView playerView;

        private void Awake()
        {
            playerInputController.OnMovementEvent += Move;
            playerInputController.OnJumpEvent += Jump;
        }

        public void Move(float horizontalInput, float verticalInput)
        {
            Vector3 movement = (cameraController.transform.forward * verticalInput + cameraController.transform.right * horizontalInput).normalized;
            movement.y = 0;
            Vector3 movePosition = movement * playerModel.MovementSpeed * Time.fixedDeltaTime;
            playerView.Move(movePosition);
        }

        public void Jump()
        {
            if (IsGrounded())
            {
                playerView.Jump(playerModel.JumpForce);
            }
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, 2);
        }
    }
}
