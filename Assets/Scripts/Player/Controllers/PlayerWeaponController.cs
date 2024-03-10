using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Models;
using Assets.Scripts.Weapons.Controllers;
using Assets.Scripts.Weapons.Models;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerWeaponController : MonoBehaviour
    {
        [SerializeField] private Transform transformWeapon;

        [Inject] private PlayerModel playerModel;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private PlayerInteractController playerInteractController;

        private WeaponController weaponController;

        private void Awake()
        {
            weaponController = playerModel.CurrentWeapon.GetComponent<WeaponController>();

            playerInputController.OnShootEvent += Attack;
            playerInputController.OnScrollEvent += ChangeCurrentWeapon;

            playerInteractController.OnObjectPickuped += PickupNewWeapon;
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

            weaponController = playerModel.CurrentWeapon.GetComponent<WeaponController>();
            playerModel.CurrentWeapon.transform.position = transformWeapon.position;
        }

        public void PickupNewWeapon(IPickupable pickupableObject)
        {
            if (pickupableObject is WeaponModel weaponModel)
            {
                var newWeapon = weaponModel.gameObject;
                playerModel.CurrentWeapon.SetActive(false);

                playerModel.Weapons.Add(newWeapon);
                playerModel.CurrentWeapon = newWeapon;
                playerModel.CurrentWeapon.SetActive(true);

                newWeapon.transform.SetParent(transformWeapon.parent);
                newWeapon.transform.localEulerAngles = new Vector3(90, 0, 0);
                newWeapon.transform.position = transformWeapon.position;

                weaponController = newWeapon.GetComponent<WeaponController>();
            }
        }
    }
}
