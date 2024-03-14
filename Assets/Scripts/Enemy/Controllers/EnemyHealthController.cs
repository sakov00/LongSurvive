using Assets.Scripts.Abstracts.Controllers;

namespace Assets.Scripts.Enemy.Controllers
{
    public class EnemyHealthController : UnitHealthController
    {
        public override void HealthModify(float value)
        {
            unitModel.ModifyHealth(value);
        }
    }
}
