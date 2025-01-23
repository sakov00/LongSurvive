using _Project.Scripts.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.Systems
{
    public class CameraSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld world;
        private EcsFilter filter;
        private EcsPool<CameraComponent> movementPool = null;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();
            movementPool = world.GetPool<CameraComponent>();
            filter = world.Filter<CameraComponent>().End();
            
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Run(EcsSystems systems)
        {
            foreach (var entityIndex in filter)
            {
                ref var cameraComponent = ref movementPool.Get(entityIndex);
                var mouseX = Input.GetAxis("Mouse X") * cameraComponent.sensitivity * Time.deltaTime;
                var mouseY = Input.GetAxis("Mouse Y") * cameraComponent.sensitivity * Time.deltaTime;
    
                var rotationX = cameraComponent.cameraTransform.localEulerAngles.x - mouseY;
                var rotationY = cameraComponent.cameraTransform.localEulerAngles.y + mouseX;
    
                if (rotationX > 180)
                    rotationX -= 360;
                else if (rotationX < -180)
                    rotationX += 360;
    
                rotationX = Mathf.Clamp(rotationX, cameraComponent.minimumVert, cameraComponent.maximumVert);
                cameraComponent.cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                cameraComponent.cameraTransform.parent.Rotate(Vector3.up * rotationY);
            }
        }
    }
}