using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullets.Models
{
    public abstract class BulletModel : MonoBehaviour, IObjectPool
    {
        public float valueDamage;
        public float bulletSpeed;
        public float lifetime = 5f;
        public Vector3 shootDirection;
        public LayerMask destroyBulletMask;

        public event Action<GameObject> OnReturnToPool;

        public void ReturnToPool()
        {
            OnReturnToPool.Invoke(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if ((destroyBulletMask & (1 << collision.gameObject.layer)) != 0)
            {
                ReturnToPool();
            }
        }
    }
}
