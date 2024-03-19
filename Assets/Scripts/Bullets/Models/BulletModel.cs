using Assets.Scripts.Components;
using Assets.Scripts.Interfaces;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Bullets.Models
{
    public abstract class BulletModel : MonoBehaviour, IObjectPool<GameObject>
    {
        [field: SerializeField, Range(-100, 100)] public float ValueDamage { get; private set; }
        [field: SerializeField, Range(0, 100)] public float BulletSpeed { get; private set; }
        [field: SerializeField, Range(0, 10)] public float Lifetime { get; private set; } = 2f;
        [field: SerializeField] public Vector3 ShootDirection { get; set; }
        [field: SerializeField] public LayerMask DestroyBulletMask { get; private set; }
        public ObjectPool<GameObject> ObjectPool { get; set; }

        public void ReturnToPool()
        {
            ObjectPool.ReturnObjectToPool(gameObject);
        }
    }
}
