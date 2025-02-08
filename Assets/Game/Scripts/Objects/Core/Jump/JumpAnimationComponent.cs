using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class JumpAnimationComponent : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _punch = new(0f, 1f, 0f);
        [SerializeField] private float _duration = 0.25f;
        [SerializeField] private int _vibrato = 1;
        [SerializeField] private float _elasticity = 1;
        [SerializeField] private JumpComponent _component;

        private void OnEnable()
        {
            _component.OnJumped += Animate;
        }

        private void OnDisable()
        {
            _component.OnJumped -= Animate;
        }

        private void Animate()
        {
            _transform.DOPunchScale(_punch, _duration, _vibrato, _elasticity);
        }
    }
}