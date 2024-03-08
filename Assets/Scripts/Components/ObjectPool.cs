using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Components
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectPrefab;
        [SerializeField] private int poolSize = 10;

        private Stack<GameObject> gameObjectPool = new Stack<GameObject>();

        [Inject] private DiContainer container;

        private void Awake()
        {
            PopulatePool();
        }

        private void PopulatePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject gameObject = container.InstantiatePrefab(gameObjectPrefab, transform.position, Quaternion.identity, null);
                gameObject.GetComponent<IObjectPool>().OnReturnToPool += ReturnObjectToPool;
                gameObject.SetActive(false);
                gameObjectPool.Push(gameObject);
            }
        }

        public GameObject GetObjectFromPool()
        {
            if (gameObjectPool.Count == 0)
            {
                GameObject gameObject = container.InstantiatePrefab(gameObjectPrefab, transform.position, Quaternion.identity, null);
                gameObject.GetComponent<IObjectPool>().OnReturnToPool += ReturnObjectToPool;
                return gameObject;
            }
            else
            {
                GameObject gameObject = gameObjectPool.Pop();
                gameObject.SetActive(true);
                return gameObject;
            }
        }

        public void ReturnObjectToPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject?.GetComponent<IResetable>()?.Reset();
            gameObjectPool.Push(gameObject);
        }
    }
}
