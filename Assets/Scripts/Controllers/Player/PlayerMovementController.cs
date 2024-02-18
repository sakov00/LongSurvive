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
            movement *= playerModel.movementSpeed;

            playerView.Move(movement);
        }

    }
}
