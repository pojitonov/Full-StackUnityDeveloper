using System;
using Game.App;

namespace Game.Gameplay
{
    public sealed class ControlsPresenter : IControlsPresenter
    {
        private readonly SaveLoader _saveLoader;

        public ControlsPresenter(SaveLoader saveLoader)
        {
            _saveLoader = saveLoader;
        }

        public async void Save(Action<bool, int> callback)
        {
            int version = await _saveLoader.Save();
            callback.Invoke(true, version);
        }

        public void Load(string versionText, Action<bool, int> callback)
        {
            int version = int.Parse(versionText);
            _saveLoader.Load(version);
            callback.Invoke(true, version);
        }
    }
}