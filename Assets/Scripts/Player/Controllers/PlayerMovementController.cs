using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Views;
using UnityEngine;
using UnityEngine.EventSystems;
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
            Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
            playerView.Move(movement * playerModel.MovementSpeed);
        }

        private void OnDrawGizmos()
        {
            // Draw a line to visualize the move direction
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward);
            Gizmos.DrawLine(transform.position, transform.position + transform.forward);
        }
    }
}
