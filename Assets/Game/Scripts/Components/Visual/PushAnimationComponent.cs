using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSource;
        
        private PushObjectsComponent _pushObjectsComponent;

        private void Awake()
        {
            _pushObjectsComponent = GetComponentInParent<PushObjectsComponent>();
        }

        private void OnEnable()
        {
            _pushObjectsComponent.OnPushed += Play;
        }

        private void OnDisable()
        {
            _pushObjectsComponent.OnPushed -= Play;
        }

        private void Play()
        {
            _particleSource.Stop();
            _particleSource.Play();
        }
    }
}