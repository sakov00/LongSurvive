using Assets.Scripts.Components;
using System;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    [RequireComponent(typeof(ObjectPool))]
    public abstract class DistanceWeaponController : WeaponController
    {
        protected ObjectPool objectPool;

        protected void Awake()
        {
            base.Awake();
            objectPool = GetComponent<ObjectPool>();
        }
    }
}
