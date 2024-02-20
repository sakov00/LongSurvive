using Assets.Scripts.Components;
using Assets.Scripts.Controllers.Player;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerInputController playerInputController;
        [SerializeField] private PlayerMovementController playerMovementController;

        [SerializeField] private Spawner spawner;

        public override void InstallBindings()
        {
            BindPlayer();
            BindMap();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerModel>().FromInstance(_playerModel).AsSingle();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.Bind<PlayerInputController>().FromInstance(playerInputController).AsSingle();
            Container.Bind<PlayerMovementController>().FromInstance(playerMovementController).AsSingle();
        }

        private void BindMap() 
        {
            Container.Bind<Spawner>().FromInstance(spawner).AsSingle();
        }
    }
}