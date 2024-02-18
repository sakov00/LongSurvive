using Assets.Scripts.Controllers.Player;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerInputController playerInputController;
        [SerializeField] private PlayerMovementController playerMovementController;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().FromInstance(_playerModel).AsSingle();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.Bind<PlayerInputController>().FromInstance(playerInputController).AsSingle();
            Container.Bind<PlayerMovementController>().FromInstance(playerMovementController).AsSingle();
        }
    }
}