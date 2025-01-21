using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Bullets.Views
{
    public abstract class BulletView : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 movement)
        {
            _rigidbody.MovePosition(_rigidbody.position + movement);
        }
    }
}
