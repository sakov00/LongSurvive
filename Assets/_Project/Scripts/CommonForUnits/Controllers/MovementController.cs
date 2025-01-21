using Assets.Scripts.CommonForUnits.Models;
using Assets.Scripts.CommonForUnits.Views;
using UnityEngine;

namespace Assets.Scripts.CommonForUnits.Controllers
{
    public abstract class MovementController : MonoBehaviour
    {
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.5f;
        [SerializeField] private LayerMask groundMask;

        [SerializeField] protected float gravity;

        protected Vector3 velocity;
        protected bool isGrounded;

        protected UnitModel unitModel;
        protected UnitView unitView;

        protected abstract void Move(Vector3 newPosition);
        protected abstract void Jump();

        protected virtual void Awake()
        {
            unitModel = GetComponent<UnitModel>();
            unitView = GetComponent<UnitView>();
        }

        protected virtual void Update()
        {
            ActiveGravity();
        }

        private void ActiveGravity()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0;
            }

            velocity.y += gravity * Mathf.Pow(Time.deltaTime, 2);
            unitView.Move(velocity);
        }
    }
}
