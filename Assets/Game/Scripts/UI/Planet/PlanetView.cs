using Modules.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Planet
{
    public class PlanetView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _incomePrefab;

        [SerializeField]
        private GameObject _pricePrefab;
        
        [SerializeField]
        private GameObject _coinPrefab;
        
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Image _lock;

        [SerializeField]
        private TMP_Text _time;

        [SerializeField]
        private TMP_Text _price;

        [SerializeField]
        private SmartButton _button;
    }
}