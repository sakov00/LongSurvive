using Assets.Scripts.Interfaces;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class WeaponModel : MonoBehaviour, IPickupable
    {
        [field: SerializeField, Range(0, 10)] public float TimeBetweenAttack { get; private set; }

        public void Pickup()
        {

        }
    }
}
