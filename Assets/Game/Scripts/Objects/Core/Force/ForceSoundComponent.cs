using UnityEngine;

namespace Game
{
    public class ForceSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private ForceComponent _forceComponent;

        private void OnEnable()
        {
            _forceComponent.OnForceApplied += Play;
        }

        private void OnDisable()
        {
            _forceComponent.OnForceApplied -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}