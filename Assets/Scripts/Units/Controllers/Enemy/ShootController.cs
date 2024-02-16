using Assets.Scripts.Units.Models;
using Assets.Scripts.Units.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Controllers.Player
{
    public abstract class ShootController : MonoBehaviour
    {
        [Inject] protected EnemyModel enemyModel;
        [Inject] protected EnemyView enemyView;

        void FixedUpdate()
        {
            Attack();
        }

        public abstract void Attack();

    }
}
