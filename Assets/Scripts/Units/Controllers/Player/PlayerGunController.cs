using Assets.Scripts.Guns;
using Assets.Scripts.Units.Models;
using Assets.Scripts.Units.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Controllers.Player
{
    public class PlayerGunController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private PlayerView playerView;

        public Gun gun;

        private void Awake()
        {
            playerInputController.OnShootEvent += Shoot;
        }

        public void Shoot(float shootInput)
        {
            if (shootInput != 0)
                gun.Shoot();
        }
    }
}
