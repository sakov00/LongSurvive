using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Components;
using Assets.Scripts.Factories;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons.Controllers
{
    public class ShotgunController : DistanceWeaponController
    {
        [Inject]
        public void Contract(BulletFactory bulletFactory)
        {
            objectPoolBullets = new ObjectPool<GameObject>(bulletFactory.CreateGunBullet, 2);
            objectPoolBullets.PopulatePool();
        }

        public override void Attack(Vector3 aimPoint)
        {
            if (DistanceWeaponModel.CanAttack)
            {
                StartCoroutine(ShootCoroutine(aimPoint));
            }
        }

        private IEnumerator ShootCoroutine(Vector3 aimPoint)
        {
            var bullet = objectPoolBullets.GetObjectFromPool();
            bullet.transform.position = DistanceWeaponModel.ShootPoint.position;
            bullet.GetComponent<BulletModel>().ShootDirection = aimPoint;

            DistanceWeaponModel.CanAttack = false;
            yield return new WaitForSeconds(DistanceWeaponModel.ShootInSecond);
            DistanceWeaponModel.CanAttack = true;
        }
    }
}
