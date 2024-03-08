using Assets.Scripts.Player.Models;
using UnityEngine;

namespace Assets.Scripts.Enemy.Controllers
{
    public class DetectionController : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float detectionRange = 20f;
        [SerializeField] private float viewAngle = 360f;

        private Collider[] colliders = new Collider[4];

        public bool IsVisiblePlayer;
        public Transform NearPlayerTransform;

        private void FixedUpdate()
        {
            IsVisiblePlayer = CanSeePlayer();
        }

        private bool CanSeePlayer()
        {
            int colliderCount = Physics.OverlapSphereNonAlloc(transform.position, detectionRange, colliders, layerMask);
            for (int i = 0; i < colliderCount; i++)
            {
                if (colliders[i].GetComponent<PlayerModel>() != null)
                {
                    NearPlayerTransform = colliders[i].transform;
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
