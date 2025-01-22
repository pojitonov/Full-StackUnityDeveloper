using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial class Context
    {
        public event Action<IContextSystem> OnSystemAdded;
        public event Action<IContextSystem> OnSystemRemoved;
        public event Action OnSystemsCleared;

        public IReadOnlyCollection<IContextSystem> Systems => this.systems;

        private readonly HashSet<IContextSystem> systems = new();

        public T GetSystem<T>() where T : IContextSystem
        {
            foreach (IContextSystem system in this.systems)
            {
                if (system is T tSystem)
                {
                    return tSystem;
                }
            }

            return default;
        }

        public bool TryGetSystem<T>(out T result) where T : IContextSystem
        {
            foreach (IContextSystem system in this.systems)
            {
                if (system is T tSystem)
                {
                    result = tSystem;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public bool HasSystem(IContextSystem system)
        {
            return this.systems.Contains(system);
        }

        public bool HasSystem<T>() where T : IContextSystem
        {
            foreach (IContextSystem system in this.systems)
            {
                if (system is T)
                {
                    return true;
                }
            }

            return false;
        }

        public bool AddSystem<T>() where T : IContextSystem, new()
        {
            return this.AddSystem(new T());
        }

        public bool AddSystem(IContextSystem system)
        {
            if (!this.systems.Add(system))
            {
                return false;
            }

            if (this.initialized && system is IContextInit initSystem)
            {
                initSystem.Init(this);
            }

            if (this.enabled && system is IContextEnable enableSystem)
            {
                enableSystem.Enable(this);
            }

            if (system is IContextUpdate update)
            {
                this.updates.Add(update);
            }

            if (system is IContextFixedUpdate fixedUpdate)
            {
                this.fixedUpdates.Add(fixedUpdate);
            }

            if (system is IContextLateUpdate lateUpdate)
            {
                this.lateUpdates.Add(lateUpdate);
            }

            this.OnSystemAdded?.Invoke(system);
            return true;
        }

        public bool DelSystem<T>() where T : IContextSystem
        {
            T system = this.GetSystem<T>();
            if (system == null)
            {
                return false;
            }

            return this.DelSystem(system);
        }

        public bool DelSystem(IContextSystem system)
        {
            if (!this.systems.Remove(system))
            {
                return false;
            }

            if (system is IContextUpdate update)
            {
                this.updates.Remove(update);
            }

            if (system is IContextFixedUpdate fixedUpdate)
            {
                this.fixedUpdates.Remove(fixedUpdate);
            }

            if (system is IContextLateUpdate lateUpdate)
            {
                this.lateUpdates.Remove(lateUpdate);
            }

            if (this.enabled && system is IContextDisable disableSystem)
            {
                disableSystem.Disable(this);
            }

            if (this.initialized && system is IContextDispose disposeSystem)
            {
                disposeSystem.Dispose(this);
            }

            this.OnSystemRemoved?.Invoke(system);
            return true;
        }
        
        public bool ClearSystems()
        {
            if (this.systems.Count <= 0)
                return false;
            
            this.systems.Clear();
            this.ClearLifecycle();
            this.OnSystemsCleared?.Invoke();
            return true;
        }
    }
}