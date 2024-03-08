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

        public override void Move()
        {
            if (detectionController.IsVisiblePlayer)
            {
                var direction = (detectionController.NearPlayerTransform.position - transform.position).normalized;
                unitView.Move(direction * unitModel.MovementSpeed);
                unitView.LookAt(detectionController.NearPlayerTransform);
            }
        }
    }
}
