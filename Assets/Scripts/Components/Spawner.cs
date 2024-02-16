using UnityEngine;

namespace Assets.Scripts.Components
{
    public class Spawner : MonoBehaviour
    {
        private ObjectPool objectPool;

        private void Awake()
        {
            objectPool = GetComponent<ObjectPool>();
        }

        public void SpawnObject()
        {
            objectPool.GetObjectFromPool();
        }
    }
}
