using _Project.Scripts.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.Systems
{
    public class SwitchWeaponSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld world;
        private EcsFilter filter;
        private EcsPool<HaveWeaponsComponent> haveWeaponsPool = null;
        private EcsPool<InputComponent> inputPool = null;

        public void Init(EcsSystems systems)
        {
            world = systems.GetWorld();
            haveWeaponsPool = world.GetPool<HaveWeaponsComponent>();
            inputPool = world.GetPool<InputComponent>();
            filter = world.Filter<HaveWeaponsComponent>().Inc<InputComponent>().End();
        }

        public void Run(EcsSystems systems)
        {
            foreach (var entityIndex in filter)
            {
                ref var haveWeapons = ref haveWeaponsPool.Get(entityIndex);
                ref var input = ref inputPool.Get(entityIndex);

                if(input.scrollInput == 0)
                    continue;
                
                if (Time.time - haveWeapons.lastSwitchTime < haveWeapons.switchWeaponInterval) 
                    continue;
                
                haveWeapons.lastSwitchTime = Time.time;
                
                haveWeapons.weapons[haveWeapons.currentWeaponIndex].SetActive(false);
                
                var scrollValue = (int)input.scrollInput;
                if (scrollValue >= 1)
                    scrollValue = 1;
                if (scrollValue <= -1)
                    scrollValue = -1;
                
                haveWeapons.currentWeaponIndex += scrollValue;
                
                if (haveWeapons.currentWeaponIndex >= haveWeapons.weapons.Count)
                    haveWeapons.currentWeaponIndex = 0; 
                else if (haveWeapons.currentWeaponIndex < 0)
                    haveWeapons.currentWeaponIndex = haveWeapons.weapons.Count - 1; 
                
                haveWeapons.weapons[haveWeapons.currentWeaponIndex].SetActive(true);
            }
        }
    }
}