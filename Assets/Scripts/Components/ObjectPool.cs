using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    //good
    public class ObjectPool<T>
    {
        private Stack<T> objectPool = new Stack<T>();
        private Func<T> objectFactory;

        private int poolSize;

        public ObjectPool(Func<T> factoryMethod, int poolSize = 10)
        {
            objectFactory = factoryMethod;
            this.poolSize = poolSize;
        }

        public void PopulatePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                T newObj = objectFactory();
                objectPool.Push(newObj);
                if (newObj is GameObject gameObject)
                {
                    gameObject.SetActive(false);
                    gameObject.GetComponent<IObjectPool<T>>().ObjectPool = this;
                }
            }
        }

        public T GetObjectFromPool()
        {
            if (objectPool.Count == 0)
            {
                T newObj = objectFactory();
                if (newObj is GameObject gameObject)
                {
                    gameObject.SetActive(true);
                    gameObject.GetComponent<IObjectPool<T>>().ObjectPool = this;
                }
                return newObj;
            }
            else
            {
                T obj = objectPool.Pop();
                if (obj is GameObject gameObject)
                {
                    gameObject.SetActive(true);
                }
                return obj;
            }
        }

        public void ReturnObjectToPool(T obj)
        {
            if (obj is GameObject gameObject)
            {
                gameObject.SetActive(false);
            }
            objectPool.Push(obj);
        }
    }
}
