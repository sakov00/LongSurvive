using Assets.Scripts.Components;
using Assets.Scripts.Controllers.TypeShoot;
using UnityEngine;

namespace Assets.Scripts.Guns
{
    [RequireComponent(typeof(ObjectPool))]
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform shootPoint;
        [SerializeField] protected float shootInSecond;

        protected bool canShoot = true;

        protected ShootController shootController;
        protected ObjectPool objectPool;

        protected void Awake()
        {
            shootController = GetComponent<ShootController>();
            objectPool = GetComponent<ObjectPool>();
        }

        private void FixedUpdate()
        {
            RotationGun();
        }

        private void RotationGun()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            Vector3 playerPos = transform.position;
            playerPos.z = 0f;

            float angle = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }

        public abstract void Shoot();
    }
}
