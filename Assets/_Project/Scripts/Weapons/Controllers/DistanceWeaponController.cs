using Assets.Scripts.Components;
using Assets.Scripts.Factories;
using Assets.Scripts.Weapons.Models;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons.Controllers
{
    public abstract class DistanceWeaponController : WeaponController
    {
        private BulletFactory bulletFactory;
        protected ObjectPool<GameObject> objectPoolBullets;

        protected DistanceWeaponModel DistanceWeaponModel => (DistanceWeaponModel)weaponModel;

        [Inject]
        public void Contract(BulletFactory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
        }

        protected override void Awake()
        {
            base.Awake();
            LoadBullets();
        }

        private void LoadBullets()
        {
            objectPoolBullets = new ObjectPool<GameObject>(() => bulletFactory.Create(DistanceWeaponModel.BulletType), 10);
            objectPoolBullets.PopulatePool();
        }
    }
}
