using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Controllers.Enemy
{
    public class FollowToPlayerController : MovementController
    {
        [Inject] private DetectionController detectionController;
        public override void Move()
        {
            if (detectionController.IsVisiblePlayer)
            {
                Vector3 direction = detectionController.NearPlayerTransform.position - transform.position;
                direction.Normalize();
                transform.position += direction * enemyModel.movementSpeed;
            }
        }
    }
}
