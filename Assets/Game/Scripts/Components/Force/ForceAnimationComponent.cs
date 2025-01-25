using Game.Scripts.Objects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class ForceAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _pushParticleSource;
        [SerializeField] private ParticleSystem _tossParticleSource;
        [FormerlySerializedAs("_forceActionComponent")]
        [SerializeField] private ForceComponent _forceComponent;

        private void OnEnable()
        {
            _forceComponent.OnPush += () => Play(_pushParticleSource);
            _forceComponent.OnToss += () => Play(_tossParticleSource);
        }

        private void OnDisable()
        {
            _forceComponent.OnPush -= () => Play(_pushParticleSource);
            _forceComponent.OnToss -= () => Play(_tossParticleSource);
        }

        private void Play(ParticleSystem particleSystem)
        {
            particleSystem.Stop();
            particleSystem.Play();
        }
    }
}