using _Project.Scripts.Systems;
using Leopotam.EcsLite;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace _Project.Scripts.Bootstrap
{
    public class EcsGameStartUp : MonoBehaviour
    {
        private EcsWorld world;

        private EcsSystems initSystems;
        private EcsSystems fixedUpdateSystems;
        private EcsSystems updateSystems;
        private EcsSystems lateUpdateSystems;

        public void Awake()
        {
            world = new EcsWorld();

            Application.targetFrameRate = -1;
            
            DeclareInitSystems();
            DeclareFixedUpdateSystems();
            DeclareUpdateSystems();
            DeclareLateUpdateSystems();
        }
        
        private void DeclareInitSystems()
        {
            initSystems = new EcsSystems(world);
            initSystems.Add(new PlayerInputSystem());
            initSystems.Init();
        }
        
        private void DeclareFixedUpdateSystems()
        {
            fixedUpdateSystems = new EcsSystems(world);
            fixedUpdateSystems.Init();
        }

        private void DeclareUpdateSystems()
        {
            updateSystems = new EcsSystems(world);
            updateSystems.Add(new GravitySystem());
            updateSystems.Add(new MovementSystem());
            updateSystems.Add(new CameraSystem());
            updateSystems.Add(new SwitchWeaponSystem());
            updateSystems.ConvertScene();
            updateSystems.Init();
        }

        private void DeclareLateUpdateSystems()
        {
            lateUpdateSystems = new EcsSystems(world);
            lateUpdateSystems.Init();
        }

        private void FixedUpdate()
            => fixedUpdateSystems?.Run();

        private void Update()
            => updateSystems?.Run();

        private void LateUpdate()
            => lateUpdateSystems?.Run();

        private void OnDestroy()
        {
            fixedUpdateSystems.Destroy();
            updateSystems.Destroy();
            lateUpdateSystems.Destroy();

            world.Destroy();
        }
    }
}