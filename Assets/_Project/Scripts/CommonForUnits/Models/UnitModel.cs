using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.CommonForUnits.Models
{
    public abstract class UnitModel : MonoBehaviour
    {
        [Range(0, 100)] public float jumpHeight;
        [Range(0, 10)] public float movementSpeed;
        public IntReactiveProperty healthPoints;

        public void ModifyHealth(int value)
        {
            healthPoints.Value += value;
            if (healthPoints.Value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
