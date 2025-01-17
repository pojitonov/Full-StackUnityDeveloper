using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DamageAnimationComponent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Color _damagedColor = Color.magenta;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private float _animationDuration = 0.2f;

        private Tween _tween;
        private Color _originalColor;

        private void Awake()
        {
            _originalColor = spriteRenderer.color;
        }

        private void OnEnable()
        {
            _healthComponent.OnHealthTaken += Animate;
        }

        private void OnDisable()
        {
            _healthComponent.OnHealthTaken -= Animate;
        }

        private void Animate()
        {
            _tween?.Kill();

            _tween = spriteRenderer
                .DOColor(_damagedColor, _animationDuration)
                .SetEase(Ease.OutBounce)
                .SetLoops(8, LoopType.Yoyo)
                .OnComplete(() => spriteRenderer.color = _originalColor);
        }
    }
}