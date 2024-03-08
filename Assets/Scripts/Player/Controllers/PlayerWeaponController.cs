using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Views;
using Assets.Scripts.Weapons.Controllers;
using Assets.Scripts.Weapons.Models;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerWeaponController : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private PlayerView playerView;

        private WeaponController weaponController;
        private WeaponModel weaponModel;

        private void Awake()
        {
            weaponModel = playerModel.CurrentWeapon.GetComponent<WeaponModel>();
            weaponController = playerModel.CurrentWeapon.GetComponent<WeaponController>();
            playerInputController.OnShootEvent += Attack;
            playerInputController.OnScrollEvent += ChangeCurrentWeapon;
        }

        public void Attack()
        {
            weaponController.Attack();
        }

        public void ChangeCurrentWeapon(float scrollInput)
        {
            playerModel.CurrentWeapon.SetActive(false);
            var currentIndex = playerModel.Weapons.IndexOf(playerModel.CurrentWeapon);
            var nextIndex = currentIndex + (int)scrollInput;

            if (nextIndex < 0)
                nextIndex = playerModel.Weapons.Count - 1;

            if (nextIndex >= playerModel.Weapons.Count)
                nextIndex = 0;

            playerModel.CurrentWeapon = playerModel.Weapons.ElementAt(nextIndex);
            playerModel.CurrentWeapon.SetActive(true);

            weaponModel = playerModel.CurrentWeapon.GetComponent<WeaponModel>();
            weaponController = playerModel.CurrentWeapon.GetComponent<WeaponController>();

        }
    }
}
