using Assets.Scripts.Components;
using Assets.Scripts.Weapons.Models;
using Assets.Scripts.Weapons.Views;
using UnityEngine;

namespace Assets.Scripts.Weapons.Controllers
{
    public abstract class WeaponController : MonoBehaviour
    {
        protected WeaponModel weaponModel;
        protected WeaponView weaponView;

        protected void Awake()
        {
            weaponModel = GetComponent<WeaponModel>();
            weaponView = GetComponent<WeaponView>();
        }

        public abstract void Attack();
    }
}
