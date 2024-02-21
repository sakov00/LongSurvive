
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class PlayerModel : UnitModel
    {
        [field: SerializeField, Range(1, 10)] public float Score { get; private set; }
    }
}
