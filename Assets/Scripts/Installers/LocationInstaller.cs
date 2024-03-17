using Assets.Scripts.Factories;
using Assets.Scripts.Markers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class LocationInstaller : MonoInstaller<LocationInstaller>, IInitializable
    {
        [SerializeField] private EnemyMarker[] enemyMarkers;
        [SerializeField] private Transform spawnPointPlayer;

        public override void InstallBindings()
        {
            BindPlayer();
            BindFactories();
            Container.BindInterfacesTo<LocationInstaller>().FromInstance(this).AsSingle();
        }

        private void BindPlayer()
        {
        }

        private void BindFactories()
        {
            Container.Bind<PlayerFactory>().AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();
        }

        public void Initialize()
        {
            var playerFactory = Container.Resolve<PlayerFactory>();
            playerFactory.Load();
            playerFactory.Create(spawnPointPlayer.position);

            var enemyFactory = Container.Resolve<EnemyFactory>();
            enemyFactory.Load();

            foreach (EnemyMarker enemyMarker in enemyMarkers)
                enemyFactory.Create(enemyMarker.enemyType, enemyMarker.transform.position);
        }
    }
}