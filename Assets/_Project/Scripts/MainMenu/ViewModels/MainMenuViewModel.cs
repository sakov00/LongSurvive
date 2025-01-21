using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MainMenu.ViewModels
{
    public class MainMenuViewModel : MonoBehaviour
    {
        public void ClickNewGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ClickContinue()
        {
            SceneManager.LoadScene(1);
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
