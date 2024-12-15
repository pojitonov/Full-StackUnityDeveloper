using System;
using UnityEngine;

namespace Game.UI.Planets
{
    public interface IPlanetPopupPresenter
    {
        string Title { get; }
        string Population { get; }
        string Level { get; }
        string Income { get; }
        string Price { get; }
        Sprite Avatar { get; }
        bool IsUpgradeButtonEnabled { get; }
        void OnUpgradeButtonClick();
        event Action OnStateChanged;

    }
}