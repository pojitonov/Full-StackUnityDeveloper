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

        public async UniTask<int> Save()
        {
            var gameState = new Dictionary<string, string>();

            foreach (ISerializer serializer in _serializers)
            {
                serializer.Serialize(gameState);
                await _repository.SetState(gameState);
            }

            return _repository.Version;
        }

        public async UniTask<bool> Load(int version)
        {
            (bool success, Dictionary<string, string> gameState) = await _repository.GetState(version);
            foreach (ISerializer serializer in _serializers)
                serializer.Deserialize(gameState);
            return success;
        }
    }
}