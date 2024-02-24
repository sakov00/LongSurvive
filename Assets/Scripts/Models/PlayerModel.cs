
using Assets.Scripts.Controllers.Game;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Models
{
    public class PlayerModel : UnitModel
    {
        [field: SerializeField, Range(0, 100)] public float Score { get; private set; }

        protected GameController gameController;

        [Inject]
        public void Construct(GameController gameController)
        {
            this.gameController = gameController;
            OnDeath += Die;
        }

        protected override void Die()
        {
            gameController.GameOver();
        }
    }
}
