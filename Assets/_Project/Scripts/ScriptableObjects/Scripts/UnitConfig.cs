using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "ScriptableObjects")]
    public class UnitConfig : ScriptableObject
    {
        [field: SerializeField, Range(1, 4)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Range(0, 100)] public float HealthPoints { get; private set; }
        [field: SerializeField, Range(-10, 0)] public float ContactDamageValue { get; private set; }
    }
}
