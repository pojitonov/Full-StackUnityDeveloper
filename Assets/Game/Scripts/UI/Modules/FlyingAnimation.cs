using UnityEngine;
using DG.Tweening;

namespace Modules.UI
{
    public class FlyingAnimation : MonoBehaviour
    {
        [SerializeField]
        private GameObject _coinStartPosition;

        [SerializeField]
        private float _flyDuration = 1f;

        [SerializeField]
        private GameObject _coinEndPosition;

        public void FlyCoinToWidget()
        {
            StopFloatingAnimation();

            _coinStartPosition.SetActive(true);
            Vector3 endPosition = _coinEndPosition.transform.position;

            _coinStartPosition.transform.DOMove(endPosition, _flyDuration)
                .SetEase(Ease.OutQuad);
        }
        
        private void StopFloatingAnimation()
        {
            FloatingAnimation floatingComponent = _coinStartPosition.GetComponent<FloatingAnimation>();
            if (floatingComponent != null)
            {
                floatingComponent.DOKill();
            }
        }
    }
}