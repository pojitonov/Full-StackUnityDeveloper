using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private PushObjectsComponent _pushObjectsComponent;

        private void OnEnable()
        {
            _pushObjectsComponent.OnPushed += Play;
        }

        private void OnDisable()
        {
            _pushObjectsComponent.OnPushed -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}