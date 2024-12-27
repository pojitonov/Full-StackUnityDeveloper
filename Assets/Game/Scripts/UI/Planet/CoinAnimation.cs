using DG.Tweening;
using Game.UI.Money;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.UI.Planet
{
    public class CoinAnimation : MonoBehaviour
    {
        [SerializeField]
        private GameObject _coinPrefab;

        [SerializeField]
        private float _flyDuration = 1f;

        [Inject]
        private MoneyView _moneyViewCoinPrefab;

        private FloatingAnimation floatingComponent;
        private Vector3 initialTransform;

        private void Awake()
        {
            floatingComponent = _coinPrefab.GetComponent<FloatingAnimation>();
            initialTransform = _coinPrefab.transform.position;
        }

        public void StartAnimation()
        {
            StopFloatingAnimation();

            _coinPrefab.SetActive(true);
            Vector3 endPosition = _moneyViewCoinPrefab.GetCoinPosition();

            _coinPrefab.transform.DOMove(endPosition, _flyDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(ResetPosition);
        }

        private void ResetPosition()
        {
            _coinPrefab.gameObject.SetActive(false);
            _coinPrefab.transform.position = initialTransform;
            StartFloatingAnimation();
        }

        private void StopFloatingAnimation()
        {
            if (floatingComponent != null)
            {
                floatingComponent.enabled = false;
            }
        }

        private void StartFloatingAnimation()
        {
            if (floatingComponent != null)
            {
                floatingComponent.enabled = true;
            }
        }
    }
}