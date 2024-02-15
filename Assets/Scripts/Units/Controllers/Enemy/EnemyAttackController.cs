using Assets.Scripts.Units.Models;
using Assets.Scripts.Units.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Controllers.Player
{
    public class EnemyAttackController : MonoBehaviour
    {
        [Inject] private PlayerView playerView;
        private EnemyModel enemyModel = new EnemyModel() { movementSpeed = 0.1f };

        void FixedUpdate()
        {
            Attack();
        }

        public void Attack() 
        {
            transform.position = Vector2.MoveTowards(transform.position, playerView.transform.position, enemyModel.movementSpeed);
        }

    }
}
