using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSource;
        
        private TossObjectsComponent _tossObjectsComponent;

        private void Awake()
        {
            _tossObjectsComponent = GetComponentInParent<TossObjectsComponent>();
        }

        private void OnEnable()
        {
            _tossObjectsComponent.OnTossed += Play;
        }

        private void OnDisable()
        {
            _tossObjectsComponent.OnTossed -= Play;
        }

        private void Play()
        {
            _particleSource.Stop();
            _particleSource.Play();
        }
    }
}