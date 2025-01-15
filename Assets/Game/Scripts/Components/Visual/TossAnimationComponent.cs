using UnityEngine;

namespace Game.Scripts
{
    public class TossAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSource;
        
        private PushComponent _pushComponent;

        private void Awake()
        {
            _pushComponent = GetComponentInParent<PushComponent>();
        }

        private void OnEnable()
        {
            _pushComponent.OnTossed += Play;
        }

        private void OnDisable()
        {
            _pushComponent.OnTossed -= Play;
        }

        private void Play()
        {
            _particleSource.Stop();
            _particleSource.Play();
        }
    }
}