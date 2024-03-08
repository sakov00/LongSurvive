using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class WeaponModel : MonoBehaviour
    {
        [field: SerializeField] public bool CanAttack { get; set; } = true;
    }
}
