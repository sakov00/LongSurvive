using _Project.Scripts.Components;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Systems
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld world;
        private EcsFilter filter;
        private EcsPool<InputComponent> inputPool = null;
        
        private PlayerInput _inputActions;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();
            inputPool = world.GetPool<InputComponent>();
            filter = world.Filter<InputComponent>().End();
            
            _inputActions = new PlayerInput();
            _inputActions.Enable();

            _inputActions.PC.Movement.performed += Movement;
            _inputActions.PC.Movement.canceled += Movement;

        }

        public void Destroy(EcsSystems systems)
        {
            _inputActions.PC.Movement.performed -= Movement;
            _inputActions.PC.Movement.canceled -= Movement;

            _inputActions.Disable();
        }

        private void Movement(InputAction.CallbackContext obj)
        {
            foreach (var entityIndex in filter)
            {
                ref var inputComponent = ref inputPool.Get(entityIndex);
                inputComponent.movementInput = obj.ReadValue<Vector3>();
            }
        }
    }
}