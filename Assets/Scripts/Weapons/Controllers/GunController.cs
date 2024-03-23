using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Components;
using Assets.Scripts.Factories;
using Assets.Scripts.Weapons.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons.Controllers
{
    public class GunController : DistanceWeaponController
    {
        protected GunModel GunModel => (GunModel)weaponModel;
        [Inject]
        public void Contract(BulletFactory bulletFactory)
        {
            objectPoolBullets = new ObjectPool<GameObject>(bulletFactory.CreateGunBullet, 10);
            objectPoolBullets.PopulatePool();
        }

        public override void Attack(Vector3 aimPoint)
        {
            var bullet = objectPoolBullets.GetObjectFromPool();
            bullet.transform.position = GunModel.ShootPoint.position;
            bullet.GetComponent<BulletModel>().ShootDirection = aimPoint;
        }
    }
}
