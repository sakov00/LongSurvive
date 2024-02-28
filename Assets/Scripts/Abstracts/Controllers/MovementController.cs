using Assets.Scripts.Enemy.Models;
using Assets.Scripts.Enemy.Views;
using UnityEngine;

namespace Assets.Scripts.Abstracts.Controllers
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
