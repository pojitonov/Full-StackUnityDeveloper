using System.Collections.Generic;
using Newtonsoft.Json;
using Zenject;

namespace Game.App
{
    public abstract class GenericSerializer<TService, TData> : IGenericSerializer
    {
        protected virtual string Key => typeof(TData).Name;

        [Inject]
        private TService _service;

        public void Serialize(IDictionary<string, string> gameState)
        {
            TData data = Serialize(_service);
            gameState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(IDictionary<string, string> gameState)
        {
            if (!gameState.TryGetValue(Key, out string json))
                return;
            TData data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize(_service, data);
        }

        protected abstract TData Serialize(TService service);
        protected abstract void Deserialize(TService service, TData data);
    }
}