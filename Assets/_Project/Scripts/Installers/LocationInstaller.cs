using _Project.Scripts.Bootstrap;
using Assets.Scripts.Factories;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBootstrap();
            BindPlayer();
            BindFactories();
        }

        private void BindBootstrap()
        {
            Container.Bind<EcsGameStartUp>().AsSingle();
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


    }
}