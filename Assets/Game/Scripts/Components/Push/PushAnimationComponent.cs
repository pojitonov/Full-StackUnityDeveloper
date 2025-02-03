using UnityEngine;

namespace Game
{
    public class PushAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSource;
        [SerializeField] private PushComponent _pushComponent;

        private void OnEnable()
        {
            _pushComponent.OnPush += () => Play(_particleSource);
        }

        private void OnDisable()
        {
            _pushComponent.OnPush -= () => Play(_particleSource);
        }

        private void Play(ParticleSystem particleSystem)
        {
            particleSystem.Stop();
            particleSystem.Play();
        }
    }
}