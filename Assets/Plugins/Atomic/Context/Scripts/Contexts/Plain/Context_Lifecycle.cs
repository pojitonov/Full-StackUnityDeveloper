using System;
using System.Collections.Generic;
using UnityEngine;

namespace Atomic.Contexts
{
    public partial class Context
    {
        public event Action OnInitiazized;
        public event Action OnEnabled;
        public event Action OnDisabled;
        public event Action OnDisposed;

        public event Action<float> OnUpdated;
        public event Action<float> OnFixedUpdated;
        public event Action<float> OnLateUpdated;

        public bool Initialized => this.initialized;
        public bool Enabled => this.enabled;

        private bool initialized;
        private bool enabled;

        private readonly List<IContextUpdate> updates = new();
        private readonly List<IContextFixedUpdate> fixedUpdates = new();
        private readonly List<IContextLateUpdate> lateUpdates = new();

        private readonly List<IContextUpdate> _updateCache = new();
        private readonly List<IContextFixedUpdate> _fixedUpdateCache = new();
        private readonly List<IContextLateUpdate> _lateUpdateCache = new();

        public void Init()
        {
            if (this.initialized)
            {
                Debug.LogWarning($"Context with name {name} is already initialized!");
                return;
            }

            foreach (IContextSystem system in this.systems)
                if (system is IContextInit initSystem)
                    initSystem.Init(this.owner);

            this.initialized = true;
            this.OnInitiazized?.Invoke();
        }

        public void Enable()
        {
            if (this.enabled)
            {
                Debug.LogWarning($"Context with name {name} is already enabled!");
                return;
            }

            if (!this.initialized)
            {
                Debug.LogError($"You can enable context only after initialize! Context: {name}");
                return;
            }

            foreach (IContextSystem system in this.systems)
                if (system is IContextEnable enableSystem)
                    enableSystem.Enable(this.owner);

            this.enabled = true;
            this.OnEnabled?.Invoke();
        }

        public void Disable()
        {
            if (!this.enabled)
            {
                Debug.LogWarning($"Context with {name} is not enabled!");
                return;
            }

            foreach (IContextSystem system in this.systems)
                if (system is IContextDisable disableSystem)
                    disableSystem.Disable(this.owner);

            this.enabled = false;
            this.OnDisabled?.Invoke();
        }

        public void Dispose()
        {
            if (!this.initialized) Debug.LogWarning($"Context with name {name} is not initialized!");
            if (this.enabled) this.Disable();

            foreach (IContextSystem system in this.systems)
                if (system is IContextDispose destroySystem)
                    destroySystem.Dispose(this.owner);

            this.initialized = false;
            this.OnDisposed?.Invoke();
        }

        public void OnUpdate(float deltaTime)
        {
            if (!this.enabled)
            {
                Debug.LogError($"You can update context if it's enabled! Context {name}");
                return;
            }

            int count = this.updates.Count;
            if (count != 0)
            {
                _updateCache.Clear();
                _updateCache.AddRange(this.updates);

                for (int i = 0; i < count; i++)
                {
                    IContextUpdate update = _updateCache[i];
                    update.OnUpdate(this.owner, deltaTime);
                }
            }

            this.OnUpdated?.Invoke(deltaTime);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (!this.enabled)
            {
                Debug.LogError($"You can update context if it's enabled! Context {name}");
                return;
            }

            int count = this.fixedUpdates.Count;
            if (count != 0)
            {
                _fixedUpdateCache.Clear();
                _fixedUpdateCache.AddRange(this.fixedUpdates);

                for (int i = 0; i < count; i++)
                {
                    IContextFixedUpdate updateSystem = _fixedUpdateCache[i];
                    updateSystem.OnFixedUpdate(this.owner, deltaTime);
                }
            }

            this.OnFixedUpdated?.Invoke(deltaTime);
        }

        public void OnLateUpdate(float deltaTime)
        {
            if (!this.enabled)
            {
                Debug.LogError($"You can update context if it's enabled! Context {name}");
                return;
            }

            int count = this.lateUpdates.Count;
            if (count != 0)
            {
                _lateUpdateCache.Clear();
                _lateUpdateCache.AddRange(this.lateUpdates);

                for (int i = 0; i < count; i++)
                {
                    IContextLateUpdate updateSystem = _lateUpdateCache[i];
                    updateSystem.OnLateUpdate(this.owner, deltaTime);
                }
            }

            this.OnLateUpdated?.Invoke(deltaTime);
        }
        
        private void ClearLifecycle()
        {
            this.updates.Clear();
            this.fixedUpdates.Clear();
            this.lateUpdates.Clear();
        }
    }
}