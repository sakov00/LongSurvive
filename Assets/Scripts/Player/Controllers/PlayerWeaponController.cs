using Assets.Scripts.Abstracts.Models;
using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Views;
using Assets.Scripts.Weapons.Controllers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerWeaponController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private PlayerView playerView;

        private List<WeaponController> weapons = new List<WeaponController>();
        public WeaponController currentWeapon;

        private void Awake()
        {
            playerInputController.OnShootEvent += Attack;
        }

        public void Attack()
        {
            currentWeapon.Attack();
        }
    }
}
