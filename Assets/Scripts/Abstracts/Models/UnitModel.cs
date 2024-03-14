using Assets.Scripts.Interfaces;
using Assets.Scripts.ScriptableObjects.Scripts;
using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Abstracts.Models
{
    public abstract class UnitModel : MonoBehaviour, IObjectPool, IResetable
    {
        public event Action<GameObject> OnReturnToPool;

        [field: SerializeField, Range(0, 100)] public float JumpHeight { get; private set; }
        [field: SerializeField, Range(0, 10)] public float MovementSpeed { get; private set; }
        [field: SerializeField] public FloatReactiveProperty HealthPoints { get; private set; }

        [Inject] protected UnitConfig unitConfig;

        public virtual void Reset()
        {
            MovementSpeed = unitConfig.MovementSpeed;
            HealthPoints.Value = unitConfig.HealthPoints;
        }

        public void ModifyHealth(float value)
        {
            HealthPoints.Value += value;
            if (HealthPoints.Value <= 0)
            {
                if (OnReturnToPool != null)
                    OnReturnToPool.Invoke(gameObject);
                else
                    Destroy(gameObject);
            }
        }
    }
}
