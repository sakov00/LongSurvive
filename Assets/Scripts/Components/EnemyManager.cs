using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class EnemyManager : MonoBehaviour
    {
        //need read only collection
        private List<GameObject> enemies = new List<GameObject>();

        public void AddEnemy(GameObject enemy)
        {
            if (!enemies.Contains(enemy))
                enemies.Add(enemy);
        }

        public void RemoveEnemy(GameObject enemy)
        {
            if (enemies.Contains(enemy))
                enemies.Add(enemy);
        }

        public List<GameObject> GetAllEnemies()
        {
            return enemies;
        }
    }
}
