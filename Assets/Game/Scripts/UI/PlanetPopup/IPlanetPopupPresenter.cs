using System;
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
        string Button { get; }
        Sprite Avatar { get; }
        bool IsUpgradeButtonEnabled { get; }
        bool IsMaxLevel { get; }

        void OnUpgradeButtonClick();
        void Unsubscribe();
    }
}