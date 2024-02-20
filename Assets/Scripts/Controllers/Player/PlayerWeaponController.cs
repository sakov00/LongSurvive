using Assets.Scripts.Guns;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerWeaponController : MonoBehaviour
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

        public Weapon weapon;

        private void Awake()
        {
            playerInputController.OnShootEvent += Shoot;
        }

        public void Shoot(float shootInput)
        {
            if (shootInput != 0)
                weapon.Shoot();
        }
    }
}
