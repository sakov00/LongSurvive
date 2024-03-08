using Assets.Scripts.Abstracts.Models;
using UnityEngine;

namespace Assets.Scripts.Abstracts.Views
{
    public abstract class UnitView : MonoBehaviour
    {
        protected Rigidbody _rigidbody;
        protected UnitModel unitModel;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            unitModel = GetComponent<UnitModel>();
        }

        public void Move(Vector3 movement)
        {
            _rigidbody.MovePosition(transform.position + movement);
        }

        public void Jump(float jumpForce)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        public void Rotation(Vector3 rotation)
        {
            transform.localEulerAngles += rotation;
        }

        public void LookAt(Transform transform)
        {
            this.transform.LookAt(transform);
        }
    }
}
