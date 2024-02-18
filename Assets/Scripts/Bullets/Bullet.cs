using Assets.Scripts.Components;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public abstract class Bullet : MonoBehaviour, IObjectPool
    {
        [SerializeField] public float valueDamage;
        [SerializeField] protected float bulletSpeed;
        [SerializeField] private float lifetime = 5f;

        public ObjectPool ObjectPool { get => objectPool; set => objectPool = value; }
        private ObjectPool objectPool;

        private void Start()
        {
            StartCoroutine(ReturnToPoolAfterLifetime());
        }

        private void FixedUpdate()
        {
            Move();
        }

        private IEnumerator ReturnToPoolAfterLifetime()
        {
            yield return new WaitForSeconds(lifetime);
            objectPool.ReturnObjectToPool(gameObject);
        }

        protected abstract void Move();
    }
}
