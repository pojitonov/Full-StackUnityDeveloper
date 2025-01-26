using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class JumpAnimationComponent : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _punch = new(0f, 1f, 0f);
        [SerializeField] private float _duration = 0.25f;
        [SerializeField] private int _vibrato = 1;
        [SerializeField] private float _elasticity = 1;
        [SerializeField] private JumpComponent _jumpComponent;

        private void OnEnable()
        {
            _jumpComponent.OnJumped += Animate;
        }

        private void OnDisable()
        {
            _jumpComponent.OnJumped -= Animate;
        }

        private void Animate()
        {
            _transform.DOPunchScale(_punch, _duration, _vibrato, _elasticity);
        }
    }
}