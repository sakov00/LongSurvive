using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Views;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerHUDViewModel : MonoBehaviour
    {
        private PlayerModel playerModel;
        private PlayerHUDView playerHUDView;

        private void Awake()
        {
            playerHUDView = GetComponent<PlayerHUDView>();
            playerModel = GetComponent<PlayerModel>();
            playerModel.healthPoints.Subscribe(x => playerHUDView.UpdateHealth(x));

        }
    }
}