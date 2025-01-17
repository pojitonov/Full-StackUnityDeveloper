using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private TossComponent _tossComponent;

        private void OnEnable()
        {
            _tossComponent.OnTossed += Play;
        }

        private void OnDisable()
        {
            _tossComponent.OnTossed -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}