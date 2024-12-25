using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Game.App
{
    public sealed class SaveLoader
    {
        private readonly IRepository _repository;
        private readonly IEnumerable<IGenericSerializer> _serializers;

        public SaveLoader(IRepository repository, IEnumerable<IGenericSerializer> serializers)
        {
            _repository = repository;
            _serializers = serializers;
        }

        public async UniTask<int> Save()
        {
            var gameState = new Dictionary<string, string>();

            foreach (IGenericSerializer serializer in _serializers)
            {
                serializer.Serialize(gameState);
            }

            await _repository.SetState(gameState);
            return _repository.LastSavedVersion;
        }

        public async UniTask<bool> Load(int version)
        {
            (bool success, Dictionary<string, string> gameState) = await _repository.GetState(version);
            foreach (IGenericSerializer serializer in _serializers)
            {
                serializer.Deserialize(gameState);
            }

            return success;
        }
    }
}