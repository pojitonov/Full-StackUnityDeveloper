using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSource;
        
        private TossComponent _tossComponent;

        private void Awake()
        {
            _tossComponent = GetComponentInParent<TossComponent>();
        }

        private void OnEnable()
        {
            _tossComponent.OnTossed += Play;
        }

        private void OnDisable()
        {
            _tossComponent.OnTossed -= Play;
        }

        private void Play()
        {
            _particleSource.Stop();
            _particleSource.Play();
        }
    }
}