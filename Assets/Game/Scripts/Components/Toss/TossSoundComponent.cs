using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private TossObjectsComponent _tossObjectsComponent;

        private void OnEnable()
        {
            _tossObjectsComponent.OnTossed += Play;
        }

        private void OnDisable()
        {
            _tossObjectsComponent.OnTossed -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}