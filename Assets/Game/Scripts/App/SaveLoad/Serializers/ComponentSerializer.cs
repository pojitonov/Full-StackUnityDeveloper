using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Zenject;

namespace Game.App
{
    public abstract class ComponentSerializer<TComponent, TData> : IComponentSerializer
    {
        public Type Type => typeof(TComponent);
        protected virtual string Key => typeof(TData).Name;

        public void Serialize(ISerializable component, IDictionary<string, string> gameState)
        {
            TData data = Serialize((TComponent)component);
            gameState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(ISerializable component, IDictionary<string, string> gameState)
        {
            if (!gameState.TryGetValue(Key, out string json))
                return;
            TData data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize((TComponent)component, data);
        }

        protected abstract TData Serialize(TComponent component);
        protected abstract void Deserialize(TComponent component, TData data);
    }
    
    public abstract class ComponentSerializer<TComponent, TService, TData> : IComponentSerializer
    {
        public Type Type => typeof(TComponent);
        protected virtual string Key => typeof(TData).Name;
        
        [Inject]
        private TService _service;

        public void Serialize(ISerializable component, IDictionary<string, string> gameState)
        {
            TData data = Serialize((TComponent)component, _service);
            gameState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(ISerializable component, IDictionary<string, string> gameState)
        {
            if (!gameState.TryGetValue(Key, out string json))
                return;
            TData data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize((TComponent)component, _service, data);
        }

        protected abstract TData Serialize(TComponent component, TService service);
        protected abstract void Deserialize(TComponent component, TService service, TData data);
    }
}