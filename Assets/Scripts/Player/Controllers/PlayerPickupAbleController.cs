﻿using Assets.Scripts.InteractableItems;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Models;
using Assets.Scripts.Weapons.Models;
using UnityEngine;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerPickupAbleController
    {
        private PlayerModel playerModel;

        public PlayerPickupAbleController(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        public void TryPickup(GameObject interactedObject)
        {
            IPickupable pickupableObject = interactedObject.GetComponent<IPickupable>();
            if (pickupableObject != null)
            {
                RealizeObject(pickupableObject);
                pickupableObject.Pickup();
            }
        }

        private void RealizeObject(IPickupable pickupableObject)
        {
            switch (pickupableObject)
            {
                case HealthPack healthPack:
                    PickupHealthPack(healthPack);
                    break;
                case WeaponModel weaponModel:
                    PickupWeapon(weaponModel);
                    break;
                case AmmoForWeapon ammoForWeapon:
                    PickupAmmo(ammoForWeapon);
                    break;
            }
        }

        private void PickupHealthPack(HealthPack healthPack)
        {
            playerModel.ModifyHealth(healthPack.HealthPoints);
        }

        private void PickupWeapon(WeaponModel weaponModel)
        {
            playerModel.CurrentWeapon.Value = weaponModel.gameObject;
        }

        private void PickupAmmo(AmmoForWeapon ammoForWeapon)
        {
            playerModel.ChangeAmmo(ammoForWeapon.BulletType, ammoForWeapon.CountAmmo);
        }
    }
}
