using Assets.Scripts.Units.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        public Image bar;

        private void Update()
        {
            if (bar != null) 
            {
                bar.fillAmount = (playerModel.healthPoints / playerModel.maxHealthPoints);
            }
        }
    }
}
