using Assets.Scripts.Player.Models;
using UnityEngine;

namespace Assets.Scripts.Enemy.Controllers
{
    public class DetectionController : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float detectionRange = 20f;
        [SerializeField] private float viewAngle = 360f;

        public bool IsVisiblePlayer;
        public Transform NearPlayerTransform;

        private void FixedUpdate()
        {
            IsVisiblePlayer = CanSeePlayer();
        }

        private bool CanSeePlayer()
        {
            var colliders = Physics.OverlapSphere(transform.position, detectionRange, layerMask);

            foreach (Collider collider in colliders)
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
