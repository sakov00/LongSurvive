using Assets.Scripts.Abstracts.Controllers;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerHealthController : UnitHealthController
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void HealthModify(float value)
        {
            unitModel.ModifyHealth(value);
        }
    }
}
