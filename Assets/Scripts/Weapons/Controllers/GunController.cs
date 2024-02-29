using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Weapons.Models;
using Assets.Scripts.Weapons.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 shootDirection = (hit.point - GunModel.shootPoint.position).normalized;
                GameObject bullet = objectPool.GetObjectFromPool();
                bullet.transform.position = GunModel.shootPoint.position;

                bullet.transform.forward = shootDirection;
                bullet.GetComponent<BulletModel>().shootDirection = shootDirection;

            }            

            GunModel.canShoot = false;
            yield return new WaitForSeconds(GunModel.shootInSecond);
            GunModel.canShoot = true;
        }
    }
}
