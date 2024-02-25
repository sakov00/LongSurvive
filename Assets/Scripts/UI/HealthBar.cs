using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;

        public Image bar;
        private float maxHealthPoints;

        public void Start()
        {
            maxHealthPoints = playerModel.HealthPoints;
        }

        private void Update()
        {
            if (bar != null) 
            {
                bar.fillAmount = (playerModel.HealthPoints / maxHealthPoints);
            }
        }
    }
}
