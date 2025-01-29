using System;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class BulletSystemInstaller : IContextInstaller<IGameContext>
    {
        [SerializeField] private SceneEntity _bulletPrefab;
        [SerializeField] private Transform _container;
        
        public void Install(IGameContext context)
        {
            context.AddBulletPool(new SceneEntityPool(_bulletPrefab, _container));
        }
    }
}