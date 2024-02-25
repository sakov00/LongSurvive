using Assets.Scripts.Controllers.General;
using UnityEngine;

namespace Assets.Scripts.Controllers.Enemy
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
                var newPosition = direction * enemyModel.MovementSpeed;
                enemyView.Move(newPosition);
            }
        }
    }
}
