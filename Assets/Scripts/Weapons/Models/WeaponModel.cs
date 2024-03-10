using Assets.Scripts.Interfaces;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class WeaponModel : MonoBehaviour, IPickupable
    {
        [field: SerializeField] public bool CanAttack { get; set; } = true;

        public void Pickup()
        {

        }
    }
}
