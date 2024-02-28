using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class MeleeWeaponModel : WeaponModel
    {
        public float damage = 10f;
        public float attackRange = 1f;
        public LayerMask attackMask;
    }
}
