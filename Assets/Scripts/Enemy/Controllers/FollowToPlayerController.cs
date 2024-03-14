using Assets.Scripts.Abstracts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Enemy.Controllers
{
    [RequireComponent(typeof(DetectionController))]
    public class FollowToPlayerController : MovementController
    {
        private DetectionController detectionController;

        protected override void Awake()
        {
            base.Awake();
            detectionController = GetComponent<DetectionController>();
        }
        protected override void Update()
        {
            base.Update();

            if (detectionController.IsVisiblePlayer)
            {
                var movementDirection = (detectionController.NearPlayerTransform.position - transform.position).normalized;
                Move(movementDirection);
            }
        }

        protected override void Move(Vector3 movementDirection)
        {
            unitView.Move(movementDirection * unitModel.MovementSpeed * Time.deltaTime);
            unitView.LookAt(detectionController.NearPlayerTransform);
        }

        protected override void Jump()
        {
            throw new System.NotImplementedException();
        }
    }
}
