using Assets.Scripts.Components;

namespace Assets.Scripts.Interfaces
{
    public interface IObjectPool<T>
    {
        ObjectPool<T> ObjectPool { get; set; }

        void ReturnToPool();
    }
}
