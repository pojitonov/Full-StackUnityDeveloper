using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PlayTossSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private PushComponent _pushComponent;

        private void OnEnable()
        {
            _pushComponent.OnTossed += Play;
        }

        private void OnDisable()
        {
            _pushComponent.OnTossed -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}