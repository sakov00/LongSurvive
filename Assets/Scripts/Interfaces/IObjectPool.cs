using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IObjectPool
    {
        public event Action<GameObject> OnReturnToPool;
    }
}
