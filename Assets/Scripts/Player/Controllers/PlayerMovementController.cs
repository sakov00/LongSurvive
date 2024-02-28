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
        }

        public void Move(float horizontalInput, float verticalInput)
        {
            Vector3 moveDirection = cameraController.transform.forward;
            moveDirection.y = 0;
            moveDirection.Normalize();

            Vector3 movement = (moveDirection * verticalInput + cameraController.transform.right * horizontalInput).normalized;
            playerView.Move(movement * playerModel.MovementSpeed);
        }

    }
}
