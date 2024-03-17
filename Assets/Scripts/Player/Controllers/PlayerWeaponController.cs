using Assets.Scripts.Player.Models;
using Assets.Scripts.Weapons.Controllers;
using Assets.Scripts.Weapons.Models;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerWeaponController : MonoBehaviour
    {
        private PlayerModel playerModel;
        private PlayerInputController playerInputController;
        private WeaponController weaponController;

        [SerializeField] private Transform transformWeapon;
        [SerializeField] private Camera _camera;

        private void Awake()
        {
            playerModel = GetComponent<PlayerModel>();
            playerInputController = GetComponent<PlayerInputController>();

            playerInputController.OnShootEvent += Attack;
            playerInputController.OnScrollEvent += ChangeCurrentWeapon;

            playerModel.CurrentWeapon.Subscribe(x => SetNextCurrentWeapon(x));
        }

        public void Attack()
        {
            weaponController.Attack(GetShootDirection());
        }

        private Vector3 GetShootDirection()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                return (hitInfo.point - playerModel.CurrentWeapon.Value.GetComponent<DistanceWeaponModel>().ShootPoint.position).normalized;
            }
            else
            {
                return ray.direction;
            }
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
