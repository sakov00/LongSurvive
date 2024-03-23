﻿using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Components;
using Assets.Scripts.Factories;
using Assets.Scripts.Weapons.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons.Controllers
{
    public class ShotgunController : DistanceWeaponController
    {
        protected ShotgunModel ShotgunModel => (ShotgunModel)weaponModel;

        [Inject]
        public void Contract(BulletFactory bulletFactory)
        {
            objectPoolBullets = new ObjectPool<GameObject>(bulletFactory.CreateGunBullet, 24);
            objectPoolBullets.PopulatePool();
        }

        public override void Attack(Vector3 aimPoint)
        {
            for (int i = 0; i < ShotgunModel.CountBullets; i++)
            {
                Quaternion spreadRotation = Quaternion.Euler(
                    Random.Range(-ShotgunModel.RadiusShooting, ShotgunModel.RadiusShooting),
                    Random.Range(-ShotgunModel.RadiusShooting, ShotgunModel.RadiusShooting),
                    Random.Range(-ShotgunModel.RadiusShooting, ShotgunModel.RadiusShooting));

                var bullet = objectPoolBullets.GetObjectFromPool();
                bullet.transform.position = ShotgunModel.ShootPoint.position;
                bullet.GetComponent<BulletModel>().ShootDirection = (spreadRotation * aimPoint).normalized;
            }
        }
    }
}
