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

        protected virtual void Awake()
        {
            bulletModel = GetComponent<BulletModel>();
            bulletView = GetComponent<BulletView>();
        }

        private void Start()
        {
            StartCoroutine(ReturnToPoolAfterLifetime());
        }

        private IEnumerator ReturnToPoolAfterLifetime()
        {
            yield return new WaitForSeconds(bulletModel.lifetime);
            bulletModel.ReturnToPool();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            bulletView.Move(bulletModel.shootDirection * bulletModel.bulletSpeed);
        }
    }
}
