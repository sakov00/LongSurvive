using Assets.Scripts.Enums;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Markers
{
    public class EnemyMarker : MonoBehaviour
    {
        public EnemyType enemyType;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 1);
            Gizmos.color = Color.white;
        }
    }
}
