using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace Game.App
{
    public sealed class Repository : IRepository
    {
        private readonly string _uri;
        private readonly string _version = "1";

        public Repository(string uri)
        {
            _uri = uri;
        }

        public async UniTask<bool> SetState(Dictionary<string, string> gameState)
        {
            string json = JsonConvert.SerializeObject(gameState);
            UnityWebRequest request = UnityWebRequest.Put($"{_uri}/save?version={_version}", json);
            await request.SendWebRequest();
            return request.result == UnityWebRequest.Result.Success;
        }

        public async UniTask<(bool, Dictionary<string, string>)> GetState()
        {
            UnityWebRequest request = UnityWebRequest.Get($"{_uri}/load?version={_version}");
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                return (false, null);
            string json = request.downloadHandler.text;
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ??
                             new Dictionary<string, string>();
            return (true, dictionary);
        }
    }
}