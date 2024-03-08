using Assets.Scripts.Abstracts.Models;
using Assets.Scripts.Bullets.Models;
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
