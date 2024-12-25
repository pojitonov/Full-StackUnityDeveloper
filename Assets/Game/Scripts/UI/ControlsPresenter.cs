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

        public void Save(Action<bool, int> callback)
        {
            try
            {
                _saveLoader.Save();
                callback.Invoke(true, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Save operation failed: {ex.Message}");
                callback.Invoke(false, -1);
            }
        }

        // TODO: Integrate versionText in loading process
        public void Load(string versionText, Action<bool, int> callback)
        {
            try
            {
                _saveLoader.Load(int.Parse(versionText));
                callback.Invoke(true, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Load operation failed: {ex.Message}");
                callback.Invoke(false, -1);
            }
        }
    }
}