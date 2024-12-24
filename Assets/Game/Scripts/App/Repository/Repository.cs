using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace Game.App
{
    public sealed class Repository : IRepository
    {
        private readonly string _uri;

        public Repository(string uri)
        {
            _uri = uri;
        }

        public async UniTask<bool> SetState(Dictionary<string, object> gameState)
        {
            string json = JsonConvert.SerializeObject(gameState);
            UnityWebRequest request = UnityWebRequest.Put($"{_uri}/save", json);
            await request.SendWebRequest();
            return request.result == UnityWebRequest.Result.Success;
        }

        public async UniTask<(bool, Dictionary<string, object>)> GetState()
        {
            UnityWebRequest request = UnityWebRequest.Get($"{_uri}/load");
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                return (false, null);
            string json = request.downloadHandler.text;
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
            return (true, dictionary);
        }
    }
}