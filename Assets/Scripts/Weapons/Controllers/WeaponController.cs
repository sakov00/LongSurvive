using Assets.Scripts.Weapons.Models;
using Assets.Scripts.Weapons.Views;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public abstract class WeaponController : MonoBehaviour
    {
        protected WeaponModel weaponModel;
        protected WeaponView weaponView;

        protected virtual void Awake()
        {
            weaponModel = GetComponent<WeaponModel>();
            weaponView = GetComponent<WeaponView>();
        }

        public abstract void Attack(Vector3 aimPoint);

        private void OnEnable()
        {
            weaponModel.CanAttack = true;
        }
    }
}
