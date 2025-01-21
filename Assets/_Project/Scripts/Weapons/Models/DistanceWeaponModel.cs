using Assets.Scripts.Enums;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class DistanceWeaponModel : WeaponModel
    {
        [field: SerializeField] public BulletType BulletType { get; private set; }
        [field: SerializeField] public Transform ShootPoint { get; private set; }
    }
}
