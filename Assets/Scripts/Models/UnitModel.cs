using Assets.Scripts.Interfaces;
using Assets.Scripts.ScriptableObjects.Units;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Models
{
    public abstract class UnitModel : MonoBehaviour, IObjectPool, IResetable
    {
        public event Action OnDeath;
        public event Action<GameObject> OnReturnToPool;

        [field: SerializeField, Range(1, 4)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Range(0,100)] public float HealthPoints { get; private set; }

        protected UnitConfig unitConfig;

        [Inject]
        public void Construct(UnitConfig unitConfig)
        {
            this.unitConfig = unitConfig;
        }

        public void ModifyHealth(float value)
        {
            HealthPoints += value;
            if (HealthPoints == 0)
            {
                OnDeath?.Invoke();
                OnReturnToPool?.Invoke(gameObject);
            }
        }

        public virtual void Reset()
        {
            MovementSpeed = unitConfig.MovementSpeed;
            HealthPoints = unitConfig.HealthPoints;
        }
    }
}
