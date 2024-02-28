using Assets.Scripts.Abstracts.Models;
using Assets.Scripts.Game;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Models
{
    public class PlayerModel : UnitModel
    {
        [field: SerializeField, Range(0, 100)] public float Score { get; private set; }

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
