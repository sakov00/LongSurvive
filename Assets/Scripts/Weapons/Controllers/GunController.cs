using Assets.Scripts.Weapons.Models;
using Assets.Scripts.Weapons.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public class GunController : DistanceWeaponController
    {
        private GunModel GunModel { get { return (GunModel)weaponModel; } }

        public override void Attack()
        {
            if (GunModel.canShoot)
            {
                StartCoroutine(ShootCoroutine());
            }
        }

        private IEnumerator ShootCoroutine()
        {
            GameObject bullet = objectPool.GetObjectFromPool();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            GunModel.canShoot = false;
            yield return new WaitForSeconds(GunModel.shootInSecond);
            GunModel.canShoot = true;
        }
    }
}
