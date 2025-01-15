using UnityEngine;

namespace Game.Scripts
{
    public class PlayDamageSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private HealthComponent _healthComponent;

        private void OnEnable()
        {
            _healthComponent.OnDamaged += Play;
        }

        private void OnDisable()
        {
            _healthComponent.OnDamaged -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}