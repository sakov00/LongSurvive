using Assets.Scripts.Components;
using Assets.Scripts.Controllers.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Game
{
    public class GameController : MonoBehaviour
    {
        private PlayerInputController playerInputController;
        private Spawner spawner;

        private bool gameOver;

        [Inject]
        public void Construct(PlayerInputController playerInputController, Spawner spawner)
        {
            this.playerInputController = playerInputController;
            this.spawner = spawner;
        }

        void Start()
        {
            gameOver = false;
            spawner.StartSpawning();
            playerInputController.EnableControls();
        }

        void Update()
        {
            if (gameOver && Input.GetKeyDown(KeyCode.R))
            {
                spawner.StartSpawning();
                playerInputController.EnableControls();
            }
        }

        public void GameOver()
        {
            gameOver = true;
            spawner.StopSpawning();
            playerInputController.DisableControls();
        }
    }
}
