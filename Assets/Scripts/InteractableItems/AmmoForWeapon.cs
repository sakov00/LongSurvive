using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.InteractableItems
{
    public class AmmoForWeapon : MonoBehaviour, IPickupable
    {
        [field: SerializeField] public BulletType BulletType { get; private set; }
        [field: SerializeField] public int CountAmmo { get; private set; }

        public void Pickup()
        {
            Destroy(gameObject);
        }
    }
}
