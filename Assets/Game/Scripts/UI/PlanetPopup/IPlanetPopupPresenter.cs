using System;
using Modules.Planets;
using UnityEngine;

namespace Game.UI.Popup
{
    public interface IPlanetPopupPresenter
    {
        event Action OnStateChanged;
        
        string Title { get; }
        string Population { get; }
        string Level { get; }
        string Income { get; }
        string Price { get; }
        string Button { get; }
        Sprite Avatar { get; }
        bool IsUpgradeButtonEnabled { get; }
        bool IsMaxLevel { get; }

        void SetPlanet(IPlanet planet);
        void OnUpgradeButtonClick();
     }
}