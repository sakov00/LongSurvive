using Assets.Scripts.Bullets;
using Assets.Scripts.Controllers.General;
using UnityEngine;

namespace Assets.Scripts.Controllers.Enemy
{
    public class EnemyHealthModifyController : HealthModifyController
    {
        protected override void HealthModify(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Bullet>() != null)
            {
                var bullet = collision.gameObject.GetComponent<Bullet>();

                unitModel.ModifyHealth(bullet.valueDamage);
                bullet.ReturnToPool();
            }
        }
    }
}
