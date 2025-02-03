using UnityEngine;

namespace Game
{
    public class TossAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSource;
        [SerializeField] private TossComponent _tossComponent;

        private void OnEnable()
        {
            _tossComponent.OnToss += () => Play(_particleSource);
        }

        private void OnDisable()
        {
            _tossComponent.OnToss -= () => Play(_particleSource);
        }

        private void Play(ParticleSystem particleSystem)
        {
            particleSystem.Stop();
            particleSystem.Play();
        }
    }
}