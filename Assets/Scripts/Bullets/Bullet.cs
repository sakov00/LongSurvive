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

        public event Action<GameObject> OnReturnToPool;

        private void Start()
        {
            StartCoroutine(ReturnToPoolAfterLifetime());
        }

        private IEnumerator ReturnToPoolAfterLifetime()
        {
            yield return new WaitForSeconds(lifetime);
            ReturnToPool();
        }

        public void ReturnToPool()
        {
            OnReturnToPool.Invoke(gameObject);
        }

        private void FixedUpdate()
        {
            Move();
        }

        protected abstract void Move();
    }
}
