using UnityEngine;

namespace Game
{
    public class PushSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private PushTossComponent _component;

        private void OnEnable()
        {
            _component.OnPushed += PlayAudio;
        }

        private void OnDisable()
        {
            _component.OnPushed -= PlayAudio;
        }

        private void PlayAudio()
        {
            Play(_audioClip);
        }

        private void Play(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}