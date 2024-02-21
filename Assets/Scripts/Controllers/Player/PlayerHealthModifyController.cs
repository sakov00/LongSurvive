using Assets.Scripts.Bullets;
using Assets.Scripts.Controllers.General;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerHealthModifyController : HealthModifyController
    {
        protected override void HealthModify(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<EnemyModel>() != null)
            {
                var enemy = collision.gameObject.GetComponent<EnemyModel>();

                unitModel.ModifyHealth(enemy.ContactDamageValue);
            }
        }
    }
}
