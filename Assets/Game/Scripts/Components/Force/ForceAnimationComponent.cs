using Game.Scripts.Objects;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class ForceAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _pushParticleSource;
        [SerializeField] private ParticleSystem _tossParticleSource;
        [SerializeField] private ForceActionComponent _forceActionComponent;

        private void OnEnable()
        {
            _forceActionComponent.OnPush += () => Play(_pushParticleSource);
            _forceActionComponent.OnToss += () => Play(_tossParticleSource);
        }

        private void OnDisable()
        {
            _forceActionComponent.OnPush -= () => Play(_pushParticleSource);
            _forceActionComponent.OnToss -= () => Play(_tossParticleSource);
        }

        private void Play(ParticleSystem particleSystem)
        {
            particleSystem.Stop();
            particleSystem.Play();
        }
    }
}