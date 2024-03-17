using Assets.Scripts.CommonForUnits.Controllers;
using Assets.Scripts.Weapons.Models;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public class KnifeController : MeleeWeaponController
    {
        private KnifeModel KnifeModel { get { return (KnifeModel)weaponModel; } }

        public override void Attack(Vector3 aimPoint)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, KnifeModel.AttackRange, KnifeModel.AttackMask))
            {
                UnitHealthController targetHealth = hitInfo.collider.GetComponent<UnitHealthController>();
                if (targetHealth != null)
                {
                    targetHealth.HealthModify(KnifeModel.Damage);
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * KnifeModel.AttackRange);
        }
    }
}
