using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Weapons.Models;
using Assets.Scripts.Components;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    [RequireComponent(typeof(ObjectPool))]
    public abstract class DistanceWeaponController : WeaponController
    {
        protected ObjectPool objectPool;

        protected override void Awake()
        {
            base.Awake();
            objectPool = GetComponent<ObjectPool>();
        }

        protected DistanceWeaponModel DistanceWeaponModel { get { return (DistanceWeaponModel)weaponModel; } }

        public override void Attack(Vector3 aimPoint)
        {
            if (DistanceWeaponModel.CanAttack)
            {
                StartCoroutine(ShootCoroutine(aimPoint));
            }
        }

        private IEnumerator ShootCoroutine(Vector3 aimPoint)
        {
            var bullet = objectPool.GetObjectFromPool();
            bullet.transform.position = DistanceWeaponModel.ShootPoint.position;
            bullet.GetComponent<BulletModel>().ShootDirection = aimPoint;

            DistanceWeaponModel.CanAttack = false;
            yield return new WaitForSeconds(DistanceWeaponModel.ShootInSecond);
            DistanceWeaponModel.CanAttack = true;
        }
    }
}
