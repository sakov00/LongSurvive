using Assets.Scripts.Controllers.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers.Menu
{
    public class MenuController : MonoBehaviour
    {
        protected GameController gameController;

        [Inject]
        public void Construct(GameController gameController)
        {
            this.gameController = gameController;
        }

        public void ClickContinue()
        {
            gameController.GameContinue();
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
