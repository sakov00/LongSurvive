using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.Enemy
{
    public class DetectionController : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float detectionRange = 10f;
        [SerializeField] private float viewAngle = 360f;

        public bool IsVisiblePlayer;
        public Transform NearPlayerTransform;

        private void FixedUpdate()
        {
            IsVisiblePlayer = CanSeePlayer();
        }

        private bool CanSeePlayer()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange, layerMask);

            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<PlayerModel>() != null)
                {
                    NearPlayerTransform = collider.transform;
                    return true;
                }
            }
            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRange);

            Vector3 viewAngleA = DirFromAngle(-viewAngle / 2, false);
            Vector3 viewAngleB = DirFromAngle(viewAngle / 2, false);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + viewAngleA * detectionRange);
            Gizmos.DrawLine(transform.position, transform.position + viewAngleB * detectionRange);
        }

        private Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}
