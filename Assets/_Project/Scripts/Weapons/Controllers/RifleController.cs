using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Weapons.Models;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public class RifleController : DistanceWeaponController
    {
        protected RifleModel RifleModel => (RifleModel)weaponModel;

        public override void Attack(Vector3 aimPoint)
        {
            var bullet = objectPoolBullets.GetObjectFromPool();
            bullet.transform.position = RifleModel.ShootPoint.position;
            bullet.GetComponent<BulletModel>().ShootDirection = aimPoint;
        }
    }
}
