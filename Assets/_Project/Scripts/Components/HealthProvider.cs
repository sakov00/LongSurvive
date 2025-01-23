using System;
using Voody.UniLeo.Lite;

namespace _Project.Scripts.Components
{
    public class HealthProvider : MonoProvider<HealthComponent>
    {
        
    }
    
    [Serializable]
    public struct HealthComponent
    {
        public int health;
    }
}