using Assets.Scripts.Units.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Gun gun;
        [SerializeField] Transform shootPoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float countShootsInSecond;
        [SerializeField] private float valueDamage;

        private bool canShoot = true;

        private void Update()
        {
            RotationGun();
        }

        private void RotationGun()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            Vector3 playerPos = gun.transform.position;
            playerPos.z = 0f;

            float angle = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }

        public void Shoot()
        {
            if(canShoot)
                StartCoroutine(ShootCoroutine());
        }

        private IEnumerator ShootCoroutine()
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);


            canShoot = false;
            yield return new WaitForSeconds(countShootsInSecond);
            canShoot = true;
        }
    }
}
