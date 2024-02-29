using Assets.Scripts.Components;
using Assets.Scripts.Player.Controllers;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons.Controllers
{
    [RequireComponent(typeof(ObjectPool))]
    public abstract class DistanceWeaponController : WeaponController
    {
        protected ObjectPool objectPool;
        [Inject] protected CameraController cameraController;

        protected void Awake()
        {
            base.Awake();
            objectPool = GetComponent<ObjectPool>();
        }
    }
}
