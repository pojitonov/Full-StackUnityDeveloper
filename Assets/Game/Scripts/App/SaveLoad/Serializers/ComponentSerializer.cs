using System.Collections.Generic;
using Newtonsoft.Json;
using Zenject;

namespace Game.App
{
    public abstract class ComponentSerializer<TComponent, TData> : IComponentSerializer
    {
        protected virtual string Key => typeof(TData).Name;

        [Inject]
        private TComponent _component;

        public void Serialize(IDictionary<string, string> gameState)
        {
            TData data = Serialize(_component);
            gameState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(IDictionary<string, string> gameState)
        {
            if (!gameState.TryGetValue(Key, out string json))
                return;
            TData data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize(_component, data);
        }

        protected abstract TData Serialize(TComponent component);
        protected abstract void Deserialize(TComponent component, TData data);
    }
    
    public abstract class ComponentSerializer<TComponent, TService, TData> : IComponentSerializer
    {
        protected virtual string Key => typeof(TData).Name;

        [Inject]
        private TComponent _component;
        
        [Inject]
        private TService _service;

        public void Serialize(IDictionary<string, string> gameState)
        {
            TData data = Serialize(_component, _service);
            gameState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(IDictionary<string, string> gameState)
        {
            if (!gameState.TryGetValue(Key, out string json))
                return;
            TData data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize(_component, _service, data);
        }

        protected abstract TData Serialize(TComponent component, TService service);
        protected abstract void Deserialize(TComponent component, TService service, TData data);
    }
}