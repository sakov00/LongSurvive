using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Weapons.Models;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public class AssaultRifleController : DistanceWeaponController
    {
        protected AssaultRifleModel AssaultRifleModel => (AssaultRifleModel)weaponModel;

        public override void Attack(Vector3 aimPoint)
        {
            var bullet = objectPoolBullets.GetObjectFromPool();
            bullet.transform.position = AssaultRifleModel.ShootPoint.position;
            bullet.GetComponent<BulletModel>().ShootDirection = aimPoint;
        }
    }
}
