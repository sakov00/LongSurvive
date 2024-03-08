using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Bullets.Views;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Bullets.Controllers
{
    public abstract class BulletController : MonoBehaviour
    {
        protected BulletModel bulletModel;
        protected BulletView bulletView;

        private float deltaLifetime;

        protected virtual void Awake()
        {
            bulletModel = GetComponent<BulletModel>();
            bulletView = GetComponent<BulletView>();
        }

        private void FixedUpdate()
        {
            Move();
            ReturnToPoolAfterLifetime();
        }

        private void Move()
        {
            bulletView.Move(bulletModel.ShootDirection * bulletModel.BulletSpeed);
        }

        private void ReturnToPoolAfterLifetime()
        {
            deltaLifetime += Time.fixedDeltaTime;
            if (deltaLifetime > bulletModel.Lifetime)
            {
                bulletModel.ReturnToPool();
                deltaLifetime = 0f;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if ((bulletModel.DestroyBulletMask & (1 << collision.gameObject.layer)) != 0)
            {
                bulletModel.ReturnToPool();
            }
        }
    }
}
