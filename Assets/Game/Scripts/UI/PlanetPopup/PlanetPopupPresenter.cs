using Modules.Planets;
using UnityEngine;

namespace Game.UI.Planets
{
    public class PlanetPopupPresenter : IPlanetPopupPresenter
    {
        public string Title => _planet?.Name ?? "Test Planet";
        public string Population => FormatPopulation(_planet?.Population ?? 1999);
        public string Level => FormatLevel(_planet?.Level ?? 1, _planet?.MaxLevel ?? 9);
        public string Income => FormatIncome(_planet?.MinuteIncome ?? 999);
        public string Price => _planet?.Price.ToString() ?? "9999";
        public Sprite Avatar => _planet?.GetIcon(true) ? _planet?.GetIcon(true) : null;
        public bool IsButtonEnabled => _moneyAdapter.IsEnough(_planet?.Price ?? 0);

        private readonly IMoneyAdapter _moneyAdapter;
        private IPlanet _planet;

        public PlanetPopupPresenter(IMoneyAdapter moneyAdapter, IPlanet planet)
        {
            _moneyAdapter = moneyAdapter;
            _planet = planet;
        }

        public void OnButtonClick()
        {
            if (_planet?.CanUnlockOrUpgrade == true)
                _moneyAdapter.Spend(_planet.Price);
        }

        public void UpdateData(IPlanet planet)
        {
            if (planet != null)
            {
                _planet = planet;
                // OnPlanetChanged?.Invoke();
            }
        }

        private static string FormatPopulation(int? population) => $"Population: {population}";

        private string FormatLevel(int? level, int? maxLevel) => $"Level: {level}/{maxLevel}";

        private static string FormatIncome(int? incomeMinute) => $"Income: {incomeMinute}$";
    }
}