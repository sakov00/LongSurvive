using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Controllers.General
{
    public abstract class HealthModifyController : MonoBehaviour
    {
        protected UnitModel unitModel;

        private void Awake()
        {
            unitModel = GetComponent<UnitModel>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HealthModify(collision);
        }

        protected abstract void HealthModify(Collision2D collision);
    }
}
