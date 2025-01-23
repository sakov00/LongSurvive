using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Voody.UniLeo.Lite;

namespace _Project.Scripts.Components
{
    public class HaveWeaponsProvider : MonoProvider<HaveWeaponsComponent>
    {
        
    }
    
    [Serializable]
    public struct HaveWeaponsComponent
    {
        public List<GameObject> weapons;
        public int currentWeaponIndex;
        
        public float switchWeaponInterval;
        [NonSerialized] public float lastSwitchTime;
    }
}