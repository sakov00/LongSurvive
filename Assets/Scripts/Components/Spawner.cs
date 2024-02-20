using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Components
{
    [RequireComponent(typeof(ObjectPool))]
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float spawnInterval = 10f;
        [SerializeField] private Transform[] spawnPoints;

        private ObjectPool objectPool;
        private float timer = 0f;

        private void Awake()
        {
            objectPool = GetComponent<ObjectPool>();
        }

        public void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnObject();
                timer = 0f;
            }
        }

        private void SpawnObject()
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newObject = objectPool.GetObjectFromPool();
            if (newObject != null)
            {
                newObject.transform.position = randomSpawnPoint.position;
                newObject.transform.rotation = randomSpawnPoint.rotation;
            }
        }

        public void StartSpawning()
        {
            enabled = true;
        }

        public void StopSpawning()
        {
            enabled = false;
        }
    }
}
