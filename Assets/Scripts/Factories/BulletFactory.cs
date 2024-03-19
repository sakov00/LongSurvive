using Assets.Scripts.Enums;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories
{
    public class BulletFactory
    {
        private readonly DiContainer _diContainer;

        private Object _gunBulletPrefab;
        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;

            LoadResources();
        }

        public void LoadResources()
        {
            _gunBulletPrefab = Resources.Load("Prefabs/GunBullet");
        }

        public GameObject Create(BulletType bulletType, Vector3 position)
        {
            GameObject bullet = null;
            switch (bulletType)
            {
                case BulletType.Gun:
                    bullet = CreateGunBullet(position);
                    break;
            }
            return bullet;
        }

        public GameObject Create(BulletType bulletType)
        {
            GameObject bullet = null;
            switch (bulletType)
            {
                case BulletType.Gun:
                    bullet = CreateGunBullet();
                    break;
            }
            return bullet;
        }

        public GameObject CreateGunBullet(Vector3 position)
        {
            return _diContainer.InstantiatePrefab(_gunBulletPrefab, position, Quaternion.identity, null);
        }

        public GameObject CreateGunBullet()
        {
            return _diContainer.InstantiatePrefab(_gunBulletPrefab);
        }
    }
}
