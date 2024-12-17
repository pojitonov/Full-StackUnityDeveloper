using System;
using UnityEngine;
using DG.Tweening;
using Zenject;

namespace Modules.UI
{
    public class FlyingAnimation : MonoBehaviour
    {
        [SerializeField]
        private GameObject _coinStartPosition;

        [SerializeField]
        private float _flyDuration = 1f;

        [Inject(Id = "CoinEndPosition")]
        private GameObject _coinEndPosition;

        private FloatingAnimation floatingComponent;
        private Vector3 initialTransform;

        private void Awake()
        {
            floatingComponent = _coinStartPosition.GetComponent<FloatingAnimation>();
            initialTransform = _coinStartPosition.transform.position;
        }

        public void FlyCoinToWidget(Action OnComplete)
        {
            StopFloatingAnimation();

            _coinStartPosition.SetActive(true);
            Vector3 endPosition = _coinEndPosition.transform.position;

            _coinStartPosition.transform.DOMove(endPosition, _flyDuration)
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