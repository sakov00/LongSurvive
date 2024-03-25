using Assets.Scripts.Bullets.Models;
using Assets.Scripts.CommonForUnits.Models;
using UnityEngine;

namespace Assets.Scripts.CommonForUnits.Controllers
{
    public abstract class UnitHealthController : MonoBehaviour
    {
        protected UnitModel unitModel;

        protected virtual void Awake()
        {
            unitModel = GetComponent<UnitModel>();
        }

        public abstract void HealthModify(int value);

        private void OnCollisionEnter(Collision collision)
        {
            var bullet = collision.gameObject.GetComponent<BulletModel>();
            if (bullet != null)
            {
                HealthModify(bullet.ValueDamage);
            }
        }
    }
}
