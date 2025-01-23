using Assets.Scripts.Player.Controllers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{
    public class MenuController : MonoBehaviour
    {


        [SerializeField] private GameObject pauseMenu;

        /*private void Awake()
        {
            playerInputController.OnPauseMenuEvent += PauseMenu;
        }*/

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
