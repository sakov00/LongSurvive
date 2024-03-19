﻿using Assets.Scripts.Player.Models;
using Assets.Scripts.Weapons.Controllers;
using Assets.Scripts.Weapons.Models;
using System;
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

            playerModel.CurrentWeapon.Subscribe(SetNextCurrentWeapon);
        }

        public void Attack()
        {
            weaponController?.Attack(GetShootDirection());
        }

        private Vector3 GetShootDirection()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            var distanceWeapon = playerModel.CurrentWeapon.Value.GetComponent<DistanceWeaponModel>();
            if (distanceWeapon != null)
            {
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    return (hitInfo.point - distanceWeapon.ShootPoint.position).normalized;
                }
                else
                {
                    return ray.direction;
                }
            }
            else
            {
                return ray.direction;
            }
        }

        public void ChangeCurrentWeapon(float scrollInput)
        {
            int currentIndex = playerModel.Weapons.IndexOf(playerModel.CurrentWeapon.Value);
            int nextIndex = (currentIndex + Mathf.RoundToInt(scrollInput)) % playerModel.Weapons.Count;
            if (nextIndex < 0)
                nextIndex += playerModel.Weapons.Count;

            playerModel.CurrentWeapon.Value = playerModel.Weapons[nextIndex];
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
