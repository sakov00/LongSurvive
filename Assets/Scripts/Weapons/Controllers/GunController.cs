using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Weapons.Models;
using System.Collections;
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
            Ray ray = cameraController.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Vector3 shootDirection = ray.direction;

            var bullet = objectPool.GetObjectFromPool();
            bullet.transform.position = GunModel.shootPoint.position;

            bullet.GetComponent<BulletModel>().shootDirection = shootDirection;        

            GunModel.canShoot = false;
            yield return new WaitForSeconds(GunModel.shootInSecond);
            GunModel.canShoot = true;
        }
    }
}
