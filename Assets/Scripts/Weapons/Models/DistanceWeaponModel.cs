using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class DistanceWeaponModel : WeaponModel
    {
        [field: SerializeField] public Transform ShootPoint { get; private set; }
    }
}
