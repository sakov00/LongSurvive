using Assets.Scripts.Components;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public abstract class UnitModel : MonoBehaviour, IObjectPool
    {
        public ObjectPool ObjectPool { get => objectPool; set => objectPool = value; }
        private ObjectPool objectPool;

        public float movementSpeed;

        public float healthPoints;
        public float maxHealthPoints;

        public void ModifyHealth(float value)
        {
            healthPoints += value;
            if (healthPoints <= 0)
            {
                if (ObjectPool != null)
                    ObjectPool.ReturnObjectToPool(gameObject);
                else
                    Destroy(gameObject);
            }
        }

        public void ResetProperties()
        {

        }
    }
}
