using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class DistanceWeaponModel : WeaponModel
    {
        [field: SerializeField] public Transform ShootPoint { get; private set; }
        [field: SerializeField, Range(0, 100)] public float ShootInSecond { get; private set; }
    }
}
