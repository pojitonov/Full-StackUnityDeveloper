using System;
using Modules.Planets;
using UnityEngine;

namespace Game.UI.Planets
{
    public class PlanetPopupPresenter : IPlanetPopupPresenter
    {
        public event Action OnStateChanged;

        public string Title => _planet?.Name ?? "Test Planet";
        public string Population => FormatPopulation(_planet?.Population ?? 1999);
        public string Level => FormatLevel(_planet?.Level ?? 1, _planet?.MaxLevel ?? 9);
        public string Income => FormatIncome(_planet?.MinuteIncome ?? 999);
        public string Price => _planet?.Price.ToString() ?? "9999";
        public Sprite Avatar => _planet?.GetIcon(true) ? _planet?.GetIcon(true) : null;
        public bool IsMaxLevel => _planet?.Level >= _planet?.MaxLevel;
        public bool IsUpgradeButtonEnabled =>
            !(_planet?.Level >= _planet.MaxLevel) && _money.IsEnough(_planet?.Price ?? 0);
        public string Button =>
            _planet?.Level == _planet?.MaxLevel ? "Not Upgradable" :
            _planet?.IsUnlocked == true ? "Upgrade" : "Unlock";
        
        private readonly IMoneyAdapter _money;
        private IPlanet _planet;

        public PlanetPopupPresenter(IMoneyAdapter money)
        {
            _money = money;
        }

        public void SetPlanet(IPlanet planet)
        {
            if (_planet != null)
            {
                _planet.OnPopulationChanged -= HandleStateChanged;
                _planet.OnUpgraded -= HandleStateChanged;
                _planet.OnUnlocked -= HandleStateChanged;
            }

            if (planet != null)
            {
                _planet = planet;
                _planet.OnPopulationChanged += HandleStateChanged;
                _planet.OnUpgraded += HandleStateChanged;
                _planet.OnUnlocked += HandleStateChanged;
            }
        }

        public void OnUpgradeButtonClick()
        {
            if (_planet?.CanUnlockOrUpgrade == true)
            {
                if (!_planet.IsUnlocked)
                    _planet.Unlock();

                if (_planet.IsUnlocked)
                    _planet.Upgrade();
            }
        }

        private void HandleStateChanged()
        {
            OnStateChanged?.Invoke();
        }

        private void HandleStateChanged(int _)
        {
            OnStateChanged?.Invoke();
        }

        private static string FormatPopulation(int? population) => $"Population: {population}";

        private string FormatLevel(int? level, int? maxLevel) => $"Level: {level}/{maxLevel}";

        private static string FormatIncome(int? incomeMinute) => $"Income: {incomeMinute}$";
    }
}