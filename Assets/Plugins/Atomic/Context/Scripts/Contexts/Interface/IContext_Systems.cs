using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial interface IContext
    {
        event Action<IContextSystem> OnSystemAdded;
        event Action<IContextSystem> OnSystemRemoved;
        event Action OnSystemsCleared;
        
        IReadOnlyCollection<IContextSystem> Systems { get; }
        
        T GetSystem<T>() where T : IContextSystem;
        bool TryGetSystem<T>(out T result) where T : IContextSystem;

        bool AddSystem(IContextSystem system);
        bool AddSystem<T>() where T : IContextSystem, new();
        
        bool DelSystem(IContextSystem system);
        bool DelSystem<T>() where T : IContextSystem;
        
        bool HasSystem(IContextSystem system);
        bool HasSystem<T>() where T : IContextSystem;

        bool ClearSystems();
    }
}