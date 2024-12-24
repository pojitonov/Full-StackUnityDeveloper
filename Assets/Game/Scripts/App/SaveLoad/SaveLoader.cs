using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.App
{
    public sealed class SaveLoader
    {
        private readonly IRepository _repository;
        private readonly IEnumerable<ISerializer> _serializers;

        public SaveLoader(IRepository repository, IEnumerable<ISerializer> serializers)
        {
            _repository = repository;
            _serializers = serializers;
        }

        public async UniTaskVoid Save()
        {
            var gameState = new Dictionary<string, object>();
            foreach (ISerializer serializer in _serializers)
            {
                serializer.Serialize(gameState);
                bool success = await _repository.SetState(gameState);
                Debug.Log($"Saved: {success}");
            }
        }

        public async UniTaskVoid Load()
        {
            (bool success, Dictionary<string, object> gameState) = await _repository.GetState();
            Debug.Log($"Saved: {success}");
            if (!success)
                return;
            foreach (ISerializer serializer in _serializers)
            {
                serializer.Dederialize(gameState);
            }
        }
    }
}