using Assets.Scripts.Units.Models;
using Assets.Scripts.Units.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Controllers.Enemy
{
    public abstract class MovementController : MonoBehaviour
    {
        [Inject] protected EnemyModel enemyModel;
        [Inject] protected EnemyView enemyView;

        void FixedUpdate()
        {
            Move();
        }

        public abstract void Move();
    }
}
