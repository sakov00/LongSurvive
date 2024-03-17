using Assets.Scripts.CommonForUnits.Models;
using UnityEngine;

namespace Assets.Scripts.Enemy.Models
{
    public class EnemyModel : UnitModel
    {
        [field: SerializeField, Range(-10, 0)] public float ContactDamageValue { get; private set; }
    }
}
