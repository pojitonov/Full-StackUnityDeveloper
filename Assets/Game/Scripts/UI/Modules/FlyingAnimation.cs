using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Modules.UI
{
    public class FlyingAnimation : MonoBehaviour
    {
        [SerializeField]
        private GameObject _coinStartPosition;

        [SerializeField]
        private GameObject _coinEndPosition;

        [SerializeField]
        private float _flyDuration = 1f;

        [Button]
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