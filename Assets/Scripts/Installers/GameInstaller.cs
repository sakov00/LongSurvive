using Assets.Scripts.Components;
using Assets.Scripts.Game;
using Assets.Scripts.Player.Controllers;
using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Views;
using Assets.Scripts.ScriptableObjects.Scripts;
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
        [SerializeField] private PlayerWeaponController playerWeaponController;
        [SerializeField] private PlayerInteractController playerInteractController;
        [SerializeField] private CameraController cameraController;
        [SerializeField] private Camera _camera;

        [SerializeField] private GameController gameController;
        [SerializeField] private Spawner spawner;
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private MenuController menuController;

        [SerializeField] private UnitConfig unitConfig;

        public override void InstallBindings()
        {
            BindPlayer();
            BindMap();
            BindScriptableObjects();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerModel>().FromInstance(_playerModel).AsSingle();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.Bind<PlayerInputController>().FromInstance(playerInputController).AsSingle();
            Container.Bind<PlayerMovementController>().FromInstance(playerMovementController).AsSingle();
            Container.Bind<PlayerWeaponController>().FromInstance(playerWeaponController).AsSingle();
            Container.Bind<PlayerPickupAbleController>().AsSingle();
            Container.Bind<PlayerClickableController>().AsSingle();
            Container.Bind<PlayerInteractController>().FromInstance(playerInteractController).AsSingle();
            Container.Bind<CameraController>().FromInstance(cameraController).AsSingle();
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
        }

        private void BindMap()
        {
            Container.Bind<GameController>().FromInstance(gameController).AsSingle();
            Container.Bind<Spawner>().FromInstance(spawner).AsSingle();
            Container.Bind<EnemyManager>().FromInstance(enemyManager).AsSingle();
            Container.Bind<MenuController>().FromInstance(menuController).AsSingle();
        }

        private void BindScriptableObjects()
        {
            Container.Bind<UnitConfig>().FromInstance(unitConfig).AsSingle();
        }
    }
}