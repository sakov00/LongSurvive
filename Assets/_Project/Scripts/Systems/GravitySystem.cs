using _Project.Scripts.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.Systems
{
    public class GravitySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld world;
        private EcsFilter filter;
        private EcsPool<MovementComponent> movementPool = null;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();
            movementPool = world.GetPool<MovementComponent>();
            filter = world.Filter<InputComponent>().Inc<MovementComponent>().End();
        }

        public void Run(EcsSystems systems)
        {
            foreach (var entityIndex in filter)
            {
                ref var movement = ref movementPool.Get(entityIndex);
                
                movement.isGrounded = Physics.CheckSphere(movement.groundCheck.position, 
                    movement.groundDistance, movement.groundMask);
                
                if (movement.isGrounded && movement.velocity.y < 0)
                {
                    movement.velocity.y = 0;
                }

                movement.velocity.y += movement.gravity * Mathf.Pow(Time.deltaTime, 2);
                movement.characterController.Move(movement.velocity);
            }
        }
    }
}