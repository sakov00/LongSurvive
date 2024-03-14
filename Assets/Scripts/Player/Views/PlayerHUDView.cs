using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player.Views
{
    public class PlayerHUDView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMeshPro;

        public void UpdateHealth(float currentHealth)
        {
            _textMeshPro.text = $"HP {currentHealth}";
        }
    }
}
