﻿using Assets.Scripts.Abstracts.Controllers;
using Assets.Scripts.Weapons.Models;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public class KnifeController : MeleeWeaponController
    {
        private KnifeModel KnifeModel { get { return (KnifeModel)weaponModel; } }

        public override void Attack()
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, KnifeModel.AttackRange, KnifeModel.AttackMask))
            {
                HealthModifyController targetHealth = hitInfo.collider.GetComponent<HealthModifyController>();
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
