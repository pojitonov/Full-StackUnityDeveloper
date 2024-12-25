using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.App
{
    public sealed class Repository : IRepository
    {
        public int LastSavedVersion { get; private set; }

        private readonly string _uri;
        private int _localVersion;
        private const string RepositoryVersionKey = "RepositoryVersion";

        public Repository(string uri)
        {
            _uri = uri;
            _localVersion = LoadVersion();
        }

        public async UniTask<bool> SetState(Dictionary<string, string> gameState)
        {
            string json = JsonConvert.SerializeObject(gameState);
            UnityWebRequest request = UnityWebRequest.Put($"{_uri}/save?version={_localVersion}", json);
            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                UpdateVersion();
                return true;
            }

            return false;
        }

        public async UniTask<(bool, Dictionary<string, string>)> GetState(int version)
        {
            UnityWebRequest request = UnityWebRequest.Get($"{_uri}/load?version={version}");
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success || request.responseCode != 200)
                return (false, null);

            string json = request.downloadHandler.text;
            var state = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ??
                             new Dictionary<string, string>();
            return (true, state);
        }

        private int LoadVersion()
        {
            if (!PlayerPrefs.HasKey(RepositoryVersionKey))
                return 1;

            return PlayerPrefs.GetInt(RepositoryVersionKey);
        }

        private void UpdateVersion()
        {
            LastSavedVersion = _localVersion;
            _localVersion++;
            PlayerPrefs.SetInt(RepositoryVersionKey, _localVersion);
            PlayerPrefs.Save();
        }
    }
}