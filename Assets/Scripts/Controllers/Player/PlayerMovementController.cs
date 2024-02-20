using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private PlayerModel playerModel;
        private PlayerInputController playerInputController;
        private PlayerView playerView;

        [Inject]
        public void Construct(PlayerModel playerModel, PlayerInputController playerInputController, PlayerView playerView) 
        {
            this.playerModel = playerModel;
            this.playerInputController = playerInputController;
            this.playerView = playerView;
        }

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
