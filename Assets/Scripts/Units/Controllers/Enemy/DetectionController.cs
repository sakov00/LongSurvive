using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Units.Controllers.Enemy
{
    public abstract class DetectionController : MonoBehaviour
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
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, layerMask);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    Vector3 directionToPlayer = collider.transform.position - transform.position;

                    // Проверяем, находится ли игрок в пределах зоны видимости врага
                    if (Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2)
                    {
                        // Проверяем, нет ли препятствий между врагом и игроком
                        if (!Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, detectionRange))
                        {
                            NearPlayerTransform = collider.transform;
                            return true;
                        }
                    }
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
