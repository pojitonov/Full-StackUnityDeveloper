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
            _healthComponent.OnStateChanged += Animate;
        }

        private void OnDestroy()
        {
            _healthComponent.OnStateChanged -= Animate;
        }

        private void Animate()
        {
            _tween?.Kill();

            _tween = spriteRenderer
                .DOColor(_damagedColor, 0.1f)
                .SetLoops(12, LoopType.Yoyo)
                .OnComplete(() => spriteRenderer.color = _originalColor);
        }
    }
}