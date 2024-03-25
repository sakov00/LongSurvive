using Assets.Scripts.CommonForUnits.Controllers;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerHealthController : UnitHealthController
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void HealthModify(int value)
        {
            unitModel.ModifyHealth(value);
        }
    }
}
