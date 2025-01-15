using UnityEngine;

namespace Game.Scripts
{
    public class PlayDestroyerSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private DestroyerComponent _destroyerComponent;

        private void OnEnable()
        {
            _destroyerComponent.OnDestroyed += Play;
        }

        private void OnDisable()
        {
            _destroyerComponent.OnDestroyed -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}