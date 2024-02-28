using Assets.Scripts.Abstracts.Controllers;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerHealthModifyController : HealthModifyController
    {
        public override void HealthModify(float value)
        {
            unitModel.ModifyHealth(value);
        }
    }
}
