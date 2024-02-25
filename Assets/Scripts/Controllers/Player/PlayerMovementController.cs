using Assets.Scripts.Controllers.Game;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private PlayerView playerView;

        private void Awake()
        {
            playerInputController.OnMovementEvent += Move;
        }

        public void Move(float horizontalInput, float verticalInput)
        {
            var movement = new Vector2(horizontalInput, verticalInput);
            movement *= playerModel.MovementSpeed;
            playerView.Move(movement);
        }

    }
}
