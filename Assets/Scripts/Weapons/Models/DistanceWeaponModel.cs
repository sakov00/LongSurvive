using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapons.Models
{
    public abstract class DistanceWeaponModel : WeaponModel
    {
        public Transform shootPoint;
        public float shootInSecond;
        public bool canShoot = true;
    }
}
