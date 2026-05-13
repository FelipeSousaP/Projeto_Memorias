using UnityEngine;

namespace Memorias.System.AudioSystem
{
    public class AudioManeger : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _allSounds;
        [SerializeField] private AudioSource _SFXSource;
        [SerializeField] private AudioSource _MusicSource;
        public static AudioManeger Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        private void Start()
        {
            PlayBackground();
        }

        public void PlaySFXSound(SFXType audioType,float volume = 1)
        {
            Instance._SFXSource.PlayOneShot(_allSounds[(int)audioType], volume);     
        }

        private void PlayBackground()
        {
            Instance._MusicSource.Play();
        }
        public void ToggleMusic()
        {
            _MusicSource.mute = !_MusicSource.mute;
        }

        public void ToggleSFX()
        {
            _SFXSource.mute = !_SFXSource.mute;
        }

        public void MusicVolume(float volume)
        {
            Instance._MusicSource.volume = volume;
        }

        public void SFXVolume(float volume)
        {
            Instance._SFXSource.volume = volume;
        }
    }
}
