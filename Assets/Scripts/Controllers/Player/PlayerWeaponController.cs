using Assets.Scripts.Controllers.Game;
using Assets.Scripts.Guns;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerWeaponController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private PlayerView playerView;

        public Weapon weapon;

        private void Awake()
        {
            playerInputController.OnShootEvent += weapon.Shoot;
        }

    }
}
