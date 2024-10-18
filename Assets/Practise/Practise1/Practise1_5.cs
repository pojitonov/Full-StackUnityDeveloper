using System;
using System.Collections.Generic;
using UnityEngine;

namespace Practise1
{
    /// Упражнение №5
    public interface IEntity
    {
        string Tag { get; }
        Vector3 Position { get; }
    }

    public interface IResource : IEntity
    {
        int Amount { get; }
    }

    public interface IEnemy : IEntity
    {
        bool IsAlive { get; }
    }

    public sealed class EntityService<T> where T : IEntity
    {
        private readonly HashSet<T> _entities = new();

        public event Action<T> OnAdded;
        public event Action<T> OnRemoved;

        public bool Add(T entity)
        {
            if (!_entities.Add(entity))
                return false;
            OnAdded?.Invoke(entity);
            return true;
        }

        public bool Remove(T entity)
        {
            if (!_entities.Remove(entity))
                return false;
            OnRemoved?.Invoke(entity);
            return true;
        }

        public bool FindClosest(Vector3 position, out T result)
        {
            float minDistance = float.MaxValue;
            result = default;

            foreach (T entity in _entities)
            {
                Vector3 vector = position - entity.Position;
                float distance = vector.sqrMagnitude;

                if (distance < minDistance)
                {
                    result = entity;
                    minDistance = distance;
                }
            }

            return result != null;
        }
    }
}