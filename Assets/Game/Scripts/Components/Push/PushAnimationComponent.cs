using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSource;
        
        private PushComponent _pushComponent;

        private void Awake()
        {
            _pushComponent = GetComponentInParent<PushComponent>();
        }

        private void OnEnable()
        {
            _pushComponent.OnPushed += Play;
        }

        private void OnDisable()
        {
            _pushComponent.OnPushed -= Play;
        }

        private void Play()
        {
            _particleSource.Stop();
            _particleSource.Play();
        }
    }
}