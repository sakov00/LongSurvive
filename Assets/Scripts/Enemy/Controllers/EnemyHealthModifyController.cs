using Assets.Scripts.Abstracts.Controllers;

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
