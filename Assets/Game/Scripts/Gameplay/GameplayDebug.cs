using Modules.Money;
using Modules.Planets;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public sealed class GameplayDebug : MonoBehaviour
    {
        [Inject]
        [ShowInInspector]
        private Planet[] _planets;
        
        [Inject]
        [ShowInInspector]
        private MoneyStorage _moneyStorage;
    }
}