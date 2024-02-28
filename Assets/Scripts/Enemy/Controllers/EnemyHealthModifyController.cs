using Assets.Scripts.Abstracts.Controllers;
using Assets.Scripts.Bullets;
using UnityEngine;

namespace Assets.Scripts.Enemy.Controllers
{
    public class EnemyHealthModifyController : HealthModifyController
    {
        public override void HealthModify(float value)
        {
            unitModel.ModifyHealth(value);
        }
    }
}
