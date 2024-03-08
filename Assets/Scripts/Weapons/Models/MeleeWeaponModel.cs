using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class MeleeWeaponModel : WeaponModel
    {
        [field: SerializeField, Range(0, 100)] public float Damage { get; private set; }
        [field: SerializeField, Range(0, 10)] public float AttackRange { get; private set; }
        [field: SerializeField] public LayerMask AttackMask { get; private set; }
    }
}
