using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public abstract class UnitModel : MonoBehaviour, IObjectPool
    {
        public event Action OnDeath;
        public event Action<GameObject> OnReturnToPool;

        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField, Range(0,100)] public float HealthPoints { get; private set; }

        public void ModifyHealth(float value)
        {
            HealthPoints += value;
            if (HealthPoints == 0)
            {
                OnDeath?.Invoke();
                OnReturnToPool?.Invoke(gameObject);
            }
        }
    }
}
