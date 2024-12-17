using System;
using Modules.Planets;
using UnityEngine;

namespace Game.UI.Planets
{
    public interface IPlanetPopupPresenter
    {
        event Action OnStateChanged;
        
        string Title { get; }
        string Population { get; }
        string Level { get; }
        string Income { get; }
        string Price { get; }
        Sprite Avatar { get; }
        bool IsUpgradeButtonEnabled { get; }
        
        void OnUpgradeButtonClick();
        void SetPlanet(IPlanet planet);
        void UnsetPlanet();
    }
}