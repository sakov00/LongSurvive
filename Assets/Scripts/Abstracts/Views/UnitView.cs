using UnityEngine;

namespace Assets.Scripts.Abstracts.Views
{
    public class UnitView : MonoBehaviour
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

        public void Rotation(Vector3 rotation)
        {
            transform.localEulerAngles = rotation;
        }
    }
}
