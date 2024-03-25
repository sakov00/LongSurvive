using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Weapons.Models;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public class GunController : DistanceWeaponController
    {
        protected GunModel GunModel => (GunModel)weaponModel;

        public override void Attack(Vector3 aimPoint)
        {
            var bullet = objectPoolBullets.GetObjectFromPool();
            bullet.transform.position = GunModel.ShootPoint.position;
            bullet.GetComponent<BulletModel>().ShootDirection = aimPoint;
        }
    }
}
