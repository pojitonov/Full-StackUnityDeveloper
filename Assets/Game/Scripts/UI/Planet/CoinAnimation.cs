using System;
using UnityEngine;
using DG.Tweening;

namespace Modules.UI
{
    public class CoinAnimation : MonoBehaviour
    {
        [SerializeField]
        private GameObject _coinStartPosition;

        [SerializeField]
        private float _flyDuration = 1f;

        private FloatingAnimation floatingComponent;
        private Vector3 initialTransform;

        private void Awake()
        {
            floatingComponent = _coinStartPosition.GetComponent<FloatingAnimation>();
            initialTransform = _coinStartPosition.transform.position;
        }

        public void FlyCoinToWidget(Vector3 position, Action OnComplete)
        {
            StopFloatingAnimation();

            _coinStartPosition.SetActive(true);
            _coinStartPosition.transform.DOMove(position, _flyDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    ResetPosition();
                    OnComplete?.Invoke();
                });
        }

        private void ResetPosition()
        {
            _coinStartPosition.gameObject.SetActive(false);
            _coinStartPosition.transform.position = initialTransform;
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