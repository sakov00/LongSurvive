using Assets.Scripts.Enemy.Models;
using Assets.Scripts.Player.Controllers;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Enemy.Controllers
{
    public class EnemyAttackController : MonoBehaviour
    {
        private EnemyModel enemyModel;

        private void Awake()
        {
            enemyModel = GetComponent<EnemyModel>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var playerHealth = collision.gameObject.GetComponent<PlayerHealthController>();
            if (playerHealth != null)
            {
                playerHealth.HealthModify(enemyModel.ContactDamageValue);
            }
        }
    }
}
