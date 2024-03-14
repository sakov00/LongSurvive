using Assets.Scripts.Abstracts.Controllers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerMovementController : MovementController
    {
        [Inject] private PlayerInputController playerInputController;

        protected override void Awake()
        {
            base.Awake();
            playerInputController.OnMovementEvent += Move;
            playerInputController.OnJumpEvent += Jump;
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Move(Vector3 movementInput)
        {
            Vector3 movement = (transform.right * movementInput.x + transform.forward * movementInput.z) * unitModel.MovementSpeed * Time.deltaTime;
            unitView.Move(movement);
        }

        protected override void Jump()
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(unitModel.JumpHeight * -2f * gravity) * Time.deltaTime;
                unitView.Move(velocity);
            }
        }
    }
}
