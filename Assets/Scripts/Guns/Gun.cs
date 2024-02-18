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

            StartCoroutine(ReturnToPoolAfterLifetime(bullet));

            canShoot = false;
            yield return new WaitForSeconds(shootReloadInSecond);
            canShoot = true;
        }

        private IEnumerator ReturnToPoolAfterLifetime(GameObject bullet)
        {
            yield return new WaitForSeconds(objectLifetime);
            objectPool.ReturnObjectToPool(bullet);
        }
    }
}
