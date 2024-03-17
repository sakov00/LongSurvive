using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories
{
    public class PlayerFactory
    {
        private readonly DiContainer _diContainer;

        private Object _playerPrefab;
        public PlayerFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            _playerPrefab = Resources.Load("Prefabs/Player");
        }

        public void Create(Vector3 position)
        {
            _diContainer.InstantiatePrefab(_playerPrefab, position, Quaternion.identity, null);
        }
    }
}
