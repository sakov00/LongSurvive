using Assets.Scripts.InteractableItems;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Models;
using Assets.Scripts.Weapons.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerPickupAbleController
    {
        private PlayerModel playerModel;

        [Inject]
        public PlayerPickupAbleController(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        public void TryPickup(GameObject interactedObject)
        {
            IPickupable pickupableObject = interactedObject.GetComponent<IPickupable>();
            if (pickupableObject != null)
            {
                pickupableObject.Pickup();
                RealizeObject(pickupableObject);
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

            }
        }

        private void PickupHealthPack(HealthPack healthPack)
        {
            playerModel.ModifyHealth(healthPack.HealthPoints);
            Object.Destroy(healthPack.gameObject);
        }

        private void PickupWeapon(WeaponModel weaponModel)
        {
            playerModel.CurrentWeapon.Value = weaponModel.gameObject;
        }
    }
}
