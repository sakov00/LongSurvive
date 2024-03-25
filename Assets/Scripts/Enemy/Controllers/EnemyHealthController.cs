using Assets.Scripts.CommonForUnits.Controllers;

namespace Assets.Scripts.Enemy.Controllers
{
    public class EnemyHealthController : UnitHealthController
    {
        public override void HealthModify(int value)
        {
            unitModel.ModifyHealth(value);
        }
    }
}
