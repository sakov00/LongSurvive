using Assets.Scripts.Components;
using Assets.Scripts.Controllers.Menu;
using Assets.Scripts.Controllers.Player;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;

        private MenuController menuController;
        private PlayerInputController playerInputController;
        private EnemyManager enemyManager;
        private Spawner spawner;

        private bool gameOver;

        [Inject]
        public void Construct(MenuController menuController, PlayerInputController playerInputController, EnemyManager enemyManager, Spawner spawner)
        {
            this.menuController = menuController;
            this.playerInputController = playerInputController;
            this.enemyManager = enemyManager;
            this.spawner = spawner;
        }

        void Start()
        {
            playerInputController.OnPauseMenuEvent += PauseMenu;
            GameContinue();
        }

        void Update()
        {
            if (gameOver && Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                spawner.StartSpawning();
                pauseMenu.SetActive(false);
            }
        }

        public void PauseMenu()
        {
            gameOver = true;
            Time.timeScale = 0;
            spawner.StopSpawning();
            pauseMenu.SetActive(true);
        }

        public void GameOver()
        {
            gameOver = true;
            Time.timeScale = 0;
            spawner.StopSpawning();
            pauseMenu.SetActive(true);
        }

        public void GameContinue()
        {
            gameOver = false;
            Time.timeScale = 1;
            spawner.StartSpawning();
            pauseMenu.SetActive(false);
        }
    }
}
