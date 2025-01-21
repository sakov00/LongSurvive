using _Project.Scripts.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.Systems
{
    public class MovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private PlayerInput _inputActions;
        
        private EcsWorld world;
        private EcsFilter filter;
        private EcsPool<InputComponent> inputPool = null;
        private EcsPool<MovementComponent> movementPool = null;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();
            inputPool = world.GetPool<InputComponent>();
            movementPool = world.GetPool<MovementComponent>();
            filter = world.Filter<InputComponent>().Inc<MovementComponent>().End();
        }

        public void Run(EcsSystems systems)
        {
            foreach (var entityIndex in filter)
            {
                ref var input = ref inputPool.Get(entityIndex);
                ref var movement = ref movementPool.Get(entityIndex);
                
                var movementVector3 =
                    (movement.transform.right * input.movementInput.x + movement.transform.forward * input.movementInput.z)
                    * movement.movementSpeed * Time.deltaTime;

                if(movement.isGrounded && input.movementInput.y != 0)
                    movement.velocity.y = Mathf.Sqrt(movement.jumpHeight * -2f * movement.gravity) * Time.deltaTime;
                
                movement.characterController.Move(movementVector3);
            }
        }
    }
}