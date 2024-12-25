using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.App
{
    public sealed class Repository : IRepository
    {
        public int SavedVersion { get; private set; }

        private readonly string _uri;
        private int _version;

        public Repository(string uri)
        {
            _uri = uri;
            _version = LoadVersion();
        }


        public async UniTask<bool> SetState(Dictionary<string, string> gameState)
        {
            string json = JsonConvert.SerializeObject(gameState);
            UnityWebRequest request = UnityWebRequest.Put($"{_uri}/save?version={_version}", json);
            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                SaveVersion(_version);
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
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ??
                             new Dictionary<string, string>();
            return (true, dictionary);
        }

        private int LoadVersion()
        {
            if (!PlayerPrefs.HasKey("RepositoryVersion"))
                return 1;

            return PlayerPrefs.GetInt("RepositoryVersion");
        }

        private void SaveVersion(int version)
        {
            SavedVersion = _version;
            _version++;
            PlayerPrefs.SetInt("RepositoryVersion", version);
            PlayerPrefs.Save();
        }
    }
}