using System.Collections.Generic;
using Newtonsoft.Json;
using Zenject;

namespace Game.App
{
    public abstract class GameSerializer<TService, TData> : IGameSerializer
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
    
    
    public abstract class GameSerializer<TService1, TService2, TData> : IGameSerializer
    {
        protected virtual string Key => typeof(TData).Name;

        [Inject]
        private TService1 _service1;

        [Inject]
        private TService2 _service2;

        public void Serialize(IDictionary<string, string> gameState)
        {
            TData data = Serialize(_service1, _service2);
            gameState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(IDictionary<string, string> gameState)
        {
            if (!gameState.TryGetValue(Key, out string json))
                return;

            TData data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize(_service1, _service2, data);
        }

        protected abstract TData Serialize(TService1 service1, TService2 entitySerializer);
        protected abstract void Deserialize(TService1 service1, TService2 entitySerializer, TData data);
    }
    
    
    public abstract class GameSerializer<TService1, TService2, TService3, TData> : IGameSerializer
    {
        protected virtual string Key => typeof(TData).Name;

        [Inject]
        private TService1 _service1;

        [Inject]
        private TService2 _service2;

        [Inject]
        private TService3 _service3;

        public void Serialize(IDictionary<string, string> gameState)
        {
            TData data = Serialize(_service1, _service2, _service3);
            gameState[Key] = JsonConvert.SerializeObject(data);
        }

        public void Deserialize(IDictionary<string, string> gameState)
        {
            if (!gameState.TryGetValue(Key, out string json))
                return;

            TData data = JsonConvert.DeserializeObject<TData>(json);
            Deserialize(_service1, _service2, _service3, data);
        }

        protected abstract TData Serialize(TService1 service1, TService2 service2, TService3 service3);
        protected abstract void Deserialize(TService1 service1, TService2 service2, TService3 service3, TData data);
    }
}