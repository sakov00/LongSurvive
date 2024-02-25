﻿using Assets.Scripts.Controllers.Game;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Menu
{
    public class MenuController : MonoBehaviour
    {
        [Inject] private PlayerInputController playerInputController;

        [SerializeField] private GameObject pauseMenu;

        private void Awake()
        {
            playerInputController.OnPauseMenuEvent += PauseMenu;
        }

        public void PauseMenu()
        {
            if (Time.timeScale == 1)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

        public void ClickContinue()
        {
            PauseMenu();
        }

        public void ClickSettings()
        {

        }

        public void ClickExit()
        {
            Application.Quit();
        }
    }
}
