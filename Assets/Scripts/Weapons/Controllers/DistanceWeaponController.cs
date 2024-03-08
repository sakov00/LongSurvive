using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Components;
using Assets.Scripts.Weapons.Models;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons.Controllers
{
    [RequireComponent(typeof(ObjectPool))]
    public abstract class DistanceWeaponController : WeaponController
    {
        private Vector3 shootDirection;

        protected ObjectPool objectPool;
        [Inject] protected Camera _camera;

        protected override void Awake()
        {
            base.Awake();
            objectPool = GetComponent<ObjectPool>();
        }

        protected DistanceWeaponModel DistanceWeaponModel { get { return (DistanceWeaponModel)weaponModel; } }

        public override void Attack()
        {
            if (DistanceWeaponModel.CanAttack)
            {
                StartCoroutine(ShootCoroutine());
            }
        }

        private IEnumerator ShootCoroutine()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                shootDirection = (hitInfo.point - DistanceWeaponModel.ShootPoint.position).normalized;
            }
            else
            {
                shootDirection = ray.direction;
            }

            var bullet = objectPool.GetObjectFromPool();
            bullet.transform.position = DistanceWeaponModel.ShootPoint.position;
            bullet.GetComponent<BulletModel>().ShootDirection = shootDirection;

            DistanceWeaponModel.CanAttack = false;
            yield return new WaitForSeconds(DistanceWeaponModel.ShootInSecond);
            DistanceWeaponModel.CanAttack = true;
        }
    }
}
