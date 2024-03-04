using Assets.Scripts.Abstracts.Models;
using Assets.Scripts.Game;
using Assets.Scripts.Weapons.Controllers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Models
{
    public class PlayerModel : UnitModel
    {
        [field: SerializeField, Range(0, 100)] public float Score { get; private set; }
        public List<GameObject> weapons;
        public GameObject currentWeapon;

        [Inject] protected GameController gameController;

        private void Awake()
        {
            OnDeath += Die;
        }

        protected override void Die()
        {
            gameController.GameOver();
        }
    }
}
