using Assets.Scripts.Factories;
using Assets.Scripts.Markers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Bootstrap
{
    public class BootstrapScene : MonoBehaviour
    {
        [SerializeField] private EnemyMarker[] enemyMarkers;
        [SerializeField] private Transform spawnPointPlayer;

        private PlayerFactory playerFactory;
        private EnemyFactory enemyFactory;

        [Inject]
        public void Contract(PlayerFactory playerFactory, EnemyFactory enemyFactory)
        {
            this.playerFactory = playerFactory;
            this.enemyFactory = enemyFactory;
        }

        public void Awake()
        {
            playerFactory.Create(spawnPointPlayer.position);

            foreach (EnemyMarker enemyMarker in enemyMarkers)
                enemyFactory.Create(enemyMarker.enemyType, enemyMarker.transform.position);
        }
    }
}
