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
        }

        public void Load()
        {
            _meleeEnemyPrefab = Resources.Load("Prefabs/MeleeEnemy");
        }

        public void Create(EnemyType enemyType, Vector3 position)
        {
            switch (enemyType)
            {
                case EnemyType.meleeEnemy:
                    _diContainer.InstantiatePrefab(_meleeEnemyPrefab, position, Quaternion.identity, null);
                    break;
            }
        }
    }
}
