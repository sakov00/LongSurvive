using Assets.Scripts.Enums;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories
{
    public class EnemyFactory
    {
        private readonly DiContainer _diContainer;

        private Object _meleeEnemyPrefab;
        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
            LoadResources();
        }

        public void LoadResources()
        {
            _meleeEnemyPrefab = Resources.Load("Prefabs/MeleeEnemy");
        }

        public void Create(EnemyType enemyType, Vector3 position)
        {
            switch (enemyType)
            {
                case EnemyType.meleeEnemy:
                    CreateMeleeEnemy(position);
                    break;
            }
        }
        public void Create(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.meleeEnemy:
                    CreateMeleeEnemy();
                    break;
            }
        }

        public void CreateMeleeEnemy(Vector3 position)
        {
            _diContainer.InstantiatePrefab(_meleeEnemyPrefab, position, Quaternion.identity, null);
        }

        public void CreateMeleeEnemy()
        {
            _diContainer.InstantiatePrefab(_meleeEnemyPrefab);
        }
    }
}
