using UnityEngine;

namespace Game.Scripts
{
    public class PushAnimationComponent : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _pushParticle;

        [SerializeField]
        private ParticleSystem _tossParticle;

        [SerializeField]
        private PushComponent _pushComponent;

        private void OnEnable()
        {
            _pushComponent.OnStateChanged += HandlePushType;
        }

        private void OnDisable()
        {
            _pushComponent.OnStateChanged -= HandlePushType;
        }

        private void HandlePushType(Vector2 direction)
        {
            Play(direction == Vector2.up ? _tossParticle : _pushParticle);
        }

        private void Play(ParticleSystem particleSystem)
        {
            if (particleSystem)
            {
                particleSystem.Stop();
                particleSystem.Play();
            }
        }
    }
}