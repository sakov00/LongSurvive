using Assets.Scripts.Bullets.Models;
using Assets.Scripts.Bullets.Views;
using Assets.Scripts.Enemy.Models;
using Assets.Scripts.Enemy.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            bulletView.Move(bulletModel.shootDirection * bulletModel.bulletSpeed);
        }

        private void ReturnToPoolAfterLifetime()
        {
            deltaLifetime += Time.fixedDeltaTime;
            if (deltaLifetime > bulletModel.lifetime)
            { 
                bulletModel.ReturnToPool();
                deltaLifetime = 0f;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if ((bulletModel.destroyBulletMask & (1 << collision.gameObject.layer)) != 0)
            {
                bulletModel.ReturnToPool();
            }
        }
    }
}
