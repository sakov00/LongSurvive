using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Guns
{
    public class Gun : Weapon
    {
        public override void Shoot()
        {
            if (canShoot)
            {
                StartCoroutine(ShootCoroutine());
            }
        }

        private IEnumerator ShootCoroutine()
        {
            GameObject bullet = objectPool.GetObjectFromPool();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            canShoot = false;
            yield return new WaitForSeconds(shootInSecond);
            canShoot = true;
        }
    }
}
