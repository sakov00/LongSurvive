using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Views;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerHUDViewModel : MonoBehaviour
    {
        [Inject] private PlayerModel playerModel;
        private PlayerHUDView playerHUDView;

        private void Awake()
        {
            playerHUDView = GetComponent<PlayerHUDView>();
            playerModel.HealthPoints.Subscribe(x => playerHUDView.UpdateHealth(x));
        }
    }
}