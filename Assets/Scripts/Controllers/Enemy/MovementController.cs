using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Enemy
{
    public abstract class MovementController : MonoBehaviour
    {
        protected EnemyModel enemyModel;
        protected EnemyView enemyView;

        public abstract void Move();

        protected virtual void Awake()
        {
            enemyModel = GetComponent<EnemyModel>();
            enemyView = GetComponent<EnemyView>();
        }

        void FixedUpdate()
        {
            Move();
        }
    }
}
