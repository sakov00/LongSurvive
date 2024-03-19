using Assets.Scripts.Components;
using Assets.Scripts.Weapons.Models;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Weapons.Controllers
{
    public abstract class DistanceWeaponController : WeaponController
    {
        protected ObjectPool<GameObject> objectPoolBullets;
        protected DistanceWeaponModel DistanceWeaponModel { get { return (DistanceWeaponModel)weaponModel; } }
    }
}
