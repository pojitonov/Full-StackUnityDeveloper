using UnityEngine;

namespace Game.Scripts.Components
{
    public class PlayThrowSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private ThrowComponent _throwComponent;

        private void OnEnable()
        {
            _throwComponent.OnThrown += Play;
        }

        private void OnDisable()
        {
            _throwComponent.OnThrown -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}