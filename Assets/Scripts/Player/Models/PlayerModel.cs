using Assets.Scripts.CommonForUnits.Models;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Player.Models
{
    public class PlayerModel : UnitModel
    {
        public float Score;
        public List<GameObject> Weapons;
        public ReactiveProperty<GameObject> CurrentWeapon;

        [SerializeField] private IntReactiveProperty ammoGun;
        [SerializeField] private IntReactiveProperty ammoShotgun;
        [SerializeField] private IntReactiveProperty ammoAssaultRifle;
        [SerializeField] private IntReactiveProperty ammoRifle;

        private void Start()
        {
            //Need ScriptableObject maybe
            healthPoints.Subscribe(value => healthPoints.Value = Mathf.Clamp(value, 0, 100));
            ammoGun.Subscribe(value => ammoGun.Value = Mathf.Clamp(value, 0, 60));
            ammoShotgun.Subscribe(value => ammoShotgun.Value = Mathf.Clamp(value, 0, 24));
            ammoAssaultRifle.Subscribe(value => ammoAssaultRifle.Value = Mathf.Clamp(value, 0, 120));
            ammoRifle.Subscribe(value => ammoRifle.Value = Mathf.Clamp(value, 0, 30));
        }

        public void ChangeAmmo(BulletType bulletType, int value)
        {
            switch (bulletType)
            {
                case BulletType.Gun: ammoGun.Value += value; break;
                case BulletType.Shotgun: ammoShotgun.Value += value; break;
                case BulletType.AssaultRifle: ammoAssaultRifle.Value += value; break;
                case BulletType.Rifle: ammoRifle.Value += value; break;
            }
        }

        public int? GetCurrentAmmo(BulletType bulletType)
        {
            switch (bulletType)
            {
                case BulletType.Gun: return ammoGun.Value;
                case BulletType.Shotgun: return ammoShotgun.Value;
                case BulletType.AssaultRifle: return ammoAssaultRifle.Value;
                case BulletType.Rifle: return ammoRifle.Value;
                default: return null;
            }
        }
    }
}
