using UnityEngine;

namespace Memorias.System.AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManeger : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _allSounds;
        private AudioSource _audioSource;
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
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioType audioType,float volume = 1)
        {
            Instance._audioSource.PlayOneShot(_allSounds[(int)audioType], volume);     
        }
    }
}
