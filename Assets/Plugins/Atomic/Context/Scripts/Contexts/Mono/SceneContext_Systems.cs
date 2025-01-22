using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial class SceneContext
    {
        public event Action<IContextSystem> OnSystemAdded
        {
            add => this.context.OnSystemAdded += value;
            remove => this.context.OnSystemAdded -= value;
        }

        public event Action<IContextSystem> OnSystemRemoved
        {
            add => this.context.OnSystemRemoved += value;
            remove => this.context.OnSystemRemoved -= value;
        }

        public event Action OnSystemsCleared
        {
            add => this.context.OnSystemsCleared += value;
            remove => this.context.OnSystemsCleared -= value;
        }

        public IReadOnlyCollection<IContextSystem> Systems => this.context.Systems;

        public T GetSystem<T>() where T : IContextSystem => this.context.GetSystem<T>();

        public bool TryGetSystem<T>(out T result) where T : IContextSystem => this.context.TryGetSystem(out result);

        public bool AddSystem(IContextSystem system) => this.context.AddSystem(system);

        public bool AddSystem<T>() where T : IContextSystem, new() => this.context.AddSystem<T>();

        public bool DelSystem(IContextSystem system) => this.context.DelSystem(system);

        public bool DelSystem<T>() where T : IContextSystem => this.context.DelSystem<T>();

        public bool HasSystem(IContextSystem system) => this.context.HasSystem(system);

        public bool HasSystem<T>() where T : IContextSystem => this.context.HasSystem<T>();
        
        public bool ClearSystems() => context.ClearSystems();

        public void Clear() => this.context.Clear();
    }
}