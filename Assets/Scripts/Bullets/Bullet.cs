using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        private Vector2 direction = Vector2.right;

        private void Update()
        {
            transform.Translate(direction * bulletSpeed * Time.deltaTime);
        }
    }
}
