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
            Container.Bind<BulletFactory>().AsSingle();
        }

        public void Initialize()
        {
            var playerFactory = Container.Resolve<PlayerFactory>();
            playerFactory.Create(spawnPointPlayer.position);

            var enemyFactory = Container.Resolve<EnemyFactory>();

            foreach (EnemyMarker enemyMarker in enemyMarkers)
                enemyFactory.Create(enemyMarker.enemyType, enemyMarker.transform.position);
        }
    }
}