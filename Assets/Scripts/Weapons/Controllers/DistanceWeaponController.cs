using Assets.Scripts.Components;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public abstract class DistanceWeaponController : WeaponController
    {
        protected ObjectPool<GameObject> objectPoolBullets;
    }
}
