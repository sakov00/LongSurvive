using Assets.Scripts.Components;
using Assets.Scripts.Controllers.Menu;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Game
{
    public class GameController : MonoBehaviour
    {
        [Inject] private MenuController menuController;
        [Inject] private PlayerInputController playerInputController;
        [Inject] private EnemyManager enemyManager;
        [Inject] private Spawner spawner;

        private bool gameOver;

        public void GameOver()
        {
            gameOver = true;
            Time.timeScale = 0;
        }

        public void GameContinue()
        {
            gameOver = false;
            Time.timeScale = 1;
        }
    }
}
