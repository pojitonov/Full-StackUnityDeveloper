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
            try
            {
                int version = await _saveLoader.Save();
                callback.Invoke(true, version);
            }
            catch (Exception)
            {
                callback.Invoke(false, -1);
            }
        }

        public async void Load(string versionText, Action<bool, int> callback)
        {
            try
            {
                int version = int.Parse(versionText);
                await _saveLoader.Load(version);
                callback.Invoke(true, version);
            }
            catch (Exception)
            {
                callback.Invoke(false, -1);
            }
        }
    }
}