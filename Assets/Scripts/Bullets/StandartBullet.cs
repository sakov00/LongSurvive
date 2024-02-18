using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    internal class StandartBullet : Bullet
    {
        private Vector2 direction = Vector2.right;

        protected override void Move()
        {
            transform.Translate(direction * bulletSpeed);
        }
    }
}
