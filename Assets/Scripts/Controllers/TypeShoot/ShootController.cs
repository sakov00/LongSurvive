using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.TypeShoot
{
    public abstract class ShootController : MonoBehaviour
    {
        protected UnitModel enemyModel;
        protected UnitView enemyView;

        private void Awake()
        {
            enemyModel = GetComponent<EnemyModel>();
            enemyView = GetComponent<EnemyView>();
        }

        void FixedUpdate()
        {
            Shoot();
        }

        public abstract void Shoot();

    }
}
