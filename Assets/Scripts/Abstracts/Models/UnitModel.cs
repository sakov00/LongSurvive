using Assets.Scripts.Interfaces;
using Assets.Scripts.ScriptableObjects.Scripts;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Abstracts.Models
{
    public abstract class UnitModel : MonoBehaviour, IObjectPool, IResetable
    {
        public event Action OnDeath;
        public event Action<GameObject> OnReturnToPool;

        [field: SerializeField, Range(0, 4)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Range(0,100)] public float HealthPoints { get; private set; }

        [Inject] protected UnitConfig unitConfig;

        public virtual void Reset()
        {
            MovementSpeed = unitConfig.MovementSpeed;
            HealthPoints = unitConfig.HealthPoints;
        }

        public void ModifyHealth(float value)
        {
            HealthPoints += value;
            if (HealthPoints <= 0)
            {
                OnDeath?.Invoke();
                OnReturnToPool?.Invoke(gameObject);
            }
        }

        protected abstract void Die();
    }
}
