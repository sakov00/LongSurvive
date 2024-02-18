using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components
{
    [RequireComponent(typeof(ObjectPool))]
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float spawnInterval = 10f;

        private ObjectPool objectPool;

        private void Awake()
        {
            objectPool = GetComponent<ObjectPool>();
        }

        private void Start()
        {
            StartCoroutine(SpawnObjects());
        }

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                objectPool.GetObjectFromPool();
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}
