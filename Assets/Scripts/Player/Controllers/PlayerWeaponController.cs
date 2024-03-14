using Assets.Scripts.Player.Models;
using Assets.Scripts.Weapons.Controllers;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerWeaponController : MonoBehaviour
    {
        [SerializeField] private Transform transformWeapon;

        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;

        private WeaponController weaponController;

        private void Awake()
        {
            playerInputController.OnShootEvent += Attack;
            playerInputController.OnScrollEvent += ChangeCurrentWeapon;

            playerModel.CurrentWeapon.Subscribe(x => SetNextCurrentWeapon(x));
        }

        public void Attack()
        {
            weaponController.Attack();
        }

        public void ChangeCurrentWeapon(float scrollInput)
        {
            var currentIndex = playerModel.Weapons.IndexOf(playerModel.CurrentWeapon.Value);
            var nextIndex = currentIndex + (int)scrollInput;

            if (nextIndex < 0)
                nextIndex = playerModel.Weapons.Count - 1;

            if (nextIndex >= playerModel.Weapons.Count)
                nextIndex = 0;

            playerModel.CurrentWeapon.Value = playerModel.Weapons.ElementAtOrDefault(nextIndex);
        }

        private void SetNextCurrentWeapon(GameObject weapon)
        {
            if (!playerModel.Weapons.Contains(weapon))
            {
                playerModel.Weapons.Add(weapon);
                weapon.transform.SetParent(transformWeapon.parent);
            }

            playerModel.Weapons.ForEach(x => x.SetActive(false));
            weapon.SetActive(true);
            weaponController = playerModel.CurrentWeapon.Value.GetComponent<WeaponController>();
            playerModel.CurrentWeapon.Value.transform.position = transformWeapon.position;
        }
    }
}
