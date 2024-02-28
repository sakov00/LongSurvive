using Assets.Scripts.Abstracts.Models;
using UnityEngine;

namespace Assets.Scripts.Abstracts.Controllers
{
    public abstract class HealthModifyController : MonoBehaviour
    {
        protected UnitModel unitModel;

        private void Awake()
        {
            unitModel = GetComponent<UnitModel>();
        }

        public abstract void HealthModify(float value);
    }
}
