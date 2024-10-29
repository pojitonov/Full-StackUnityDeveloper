using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class Spawner<T> where T : MonoBehaviour
    {
        private Transform worldTransform;
        private Transform container;
        private T prefab;
        private Queue<T> objPool = new();

        public Spawner(T prefab, Transform container, Transform worldTransform)
        {
            this.prefab = prefab;
            this.container = container;
            this.worldTransform = worldTransform;
        }

        public void CreateInstances(int items)
        {
            for (var i = 0; i < items; i++)
            {
                T obj = Object.Instantiate(prefab, container);
                objPool.Enqueue(obj);
            }
        }

        public T Spawn()
        {
            if (objPool.TryDequeue(out var obj))
            {
                obj.transform.SetParent(worldTransform);
            }
            else
            {
                obj = Object.Instantiate(prefab, worldTransform);
            }

            return obj;
        }

        public void Recycle(T obj)
        {
            obj.transform.SetParent(container);
            objPool.Enqueue(obj);
        }
    }
}