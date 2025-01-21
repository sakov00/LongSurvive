using Assets.Scripts.Enums;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories
{
    public class BulletFactory
    {
        private readonly DiContainer _diContainer;

        private Object _gunBulletPrefab;
        private Object _shotgunBulletPrefab;
        private Object _assaultRifleBulletPrefab;
        private Object _rifleBulletPrefab;

        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;

            LoadResources();
        }

        public void LoadResources()
        {
            _gunBulletPrefab = Resources.Load("Prefabs/Bullets/GunBullet");
            _shotgunBulletPrefab = Resources.Load("Prefabs/Bullets/ShotgunBullet");
            _assaultRifleBulletPrefab = Resources.Load("Prefabs/Bullets/AssaultRifleBullet");
            _rifleBulletPrefab = Resources.Load("Prefabs/Bullets/RifleBullet");
        }

        public GameObject Create(BulletType bulletType, Vector3 position)
        {
            GameObject bullet = null;
            switch (bulletType)
            {
                case BulletType.Gun:
                    bullet = _diContainer.InstantiatePrefab(_gunBulletPrefab, position, Quaternion.identity, null);
                    break;
                case BulletType.Shotgun:
                    bullet = _diContainer.InstantiatePrefab(_shotgunBulletPrefab, position, Quaternion.identity, null);
                    break;
                case BulletType.AssaultRifle:
                    bullet = _diContainer.InstantiatePrefab(_assaultRifleBulletPrefab, position, Quaternion.identity, null);
                    break;
                case BulletType.Rifle:
                    bullet = _diContainer.InstantiatePrefab(_rifleBulletPrefab, position, Quaternion.identity, null);
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
                    bullet = _diContainer.InstantiatePrefab(_gunBulletPrefab);
                    break;
                case BulletType.Shotgun:
                    bullet = _diContainer.InstantiatePrefab(_shotgunBulletPrefab);
                    break;
                case BulletType.AssaultRifle:
                    bullet = _diContainer.InstantiatePrefab(_assaultRifleBulletPrefab);
                    break;
                case BulletType.Rifle:
                    bullet = _diContainer.InstantiatePrefab(_rifleBulletPrefab);
                    break;
            }
            return bullet;
        }
    }
}
