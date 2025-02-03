using UnityEngine;

namespace Game
{
    public class TakeDamageSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private HealthComponent _healthComponent;

        private void OnEnable()
        {
            _healthComponent.OnHealthTaken += Play;
        }

        private void OnDisable()
        {
            _healthComponent.OnHealthTaken -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}