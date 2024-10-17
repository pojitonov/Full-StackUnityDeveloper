using System;
using System.Collections.Generic;
using UnityEngine;

namespace Practise1
{
    /// Упражнение №5
    public interface IResource
    {
        string Tag { get; }
        int Amount { get; }
        Vector3 Position { get; }
    }

    public sealed class ResourceService
    {
        public event Action<IResource> OnAdded;
        public event Action<IResource> OnRemoved;

        private readonly HashSet<IResource> resources = new();

        public bool Add(IResource resource)
        {
            if (!this.resources.Add(resource))
                return false;

            this.OnAdded?.Invoke(resource);
            return true;
        }

        public bool Remove(IResource resource)
        {
            if (!this.resources.Remove(resource))
                return false;

            this.OnRemoved?.Invoke(resource);
            return true;
        }

        public bool FindClosest(Vector3 position, out IResource result)
        {
            float minDistance = float.MaxValue;
            result = null;

            foreach (IResource resource in this.resources)
            {
                if (resource.Amount == 0)
                    continue;

                Vector3 vector = position - resource.Position;
                float distance = vector.sqrMagnitude;

                if (distance < minDistance)
                {
                    result = resource;
                    minDistance = distance;
                }
            }

            return result != null;
        }
    }

    public interface IEnemy
    {
        string Tag { get; }
        bool IsAlive { get; }
        Vector3 Position { get; }
    }

    public sealed class EnemyService
    {
        private readonly HashSet<IEnemy> enemies = new();

        public bool Add(IEnemy enemy) => this.enemies.Add(enemy);
        public bool Remove(IEnemy enemy) => this.enemies.Remove(enemy);
        public bool Contains(IEnemy enemy) => this.enemies.Contains(enemy);

        public IEnumerable<IEnemy> FindAllWithTag(string tag)
        {
            foreach (IEnemy enemy in enemies)
                if (enemy.IsAlive && enemy.Tag == tag)
                    yield return enemy;
        }
    }
}