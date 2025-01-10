using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class DamageAnimationComponent : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Color _damagedColor = Color.red;

        [SerializeField]
        private HealthComponent _healthComponent;

        private Tween _tween;
        private Color _originalColor;

        private void Awake()
        {
            _originalColor = spriteRenderer.color;
        }

        private void OnEnable()
        {
            _healthComponent.OnStateChanged += Animate;
        }

        private void OnDisable()
        {
            _healthComponent.OnStateChanged -= Animate;
        }

        private void Animate()
        {
            _tween?.Kill();

            _tween = spriteRenderer
                .DOColor(_damagedColor, 0.1f)
                .SetEase(Ease.OutBounce)
                .SetLoops(8, LoopType.Yoyo)
                .OnComplete(() => spriteRenderer.color = _originalColor);
        }
    }
}