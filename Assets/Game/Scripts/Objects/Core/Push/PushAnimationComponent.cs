using UnityEngine;

namespace Game
{
    public class PushAnimationComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSource;
        [SerializeField] private PushComponent _component;

        private void OnEnable()
        {
            _component.OnPushed += PlayAnimation;
        }

        private void OnDisable()
        {
            _component.OnPushed -= PlayAnimation;
        }

        private void PlayAnimation()
        {
            Play(_particleSource);
        }
        
        private void Play(ParticleSystem particleSystem)
        {
            particleSystem.Stop();
            particleSystem.Play();
        }
    }
}