using Assets.Scripts.CommonForUnits.Controllers;
using UnityEngine;

namespace Assets.Scripts.Player.Controllers
{
    public class PlayerMovementController : MovementController
    {
        private PlayerInputController playerInputController;

        protected override void Awake()
        {
            base.Awake();
            playerInputController = GetComponent<PlayerInputController>();
            playerInputController.OnMovementEvent += Move;
            playerInputController.OnJumpEvent += Jump;
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Move(Vector3 movementInput)
        {
            Vector3 movement = (transform.right * movementInput.x + transform.forward * movementInput.z) * unitModel.movementSpeed * Time.deltaTime;
            unitView.Move(movement);
        }

        protected override void Jump()
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(unitModel.jumpHeight * -2f * gravity) * Time.deltaTime;
                unitView.Move(velocity);
            }
        }
    }
}
