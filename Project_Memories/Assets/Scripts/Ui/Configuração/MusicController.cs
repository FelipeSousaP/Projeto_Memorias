using Memorias.System.AudioSystem;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SfxSlider;
    public void ToggleMusic() => AudioManeger.Instance.ToggleMusic();
    public void ToggleSFX() => AudioManeger.Instance.ToggleSFX();
        
    public void MusicVolume()
    {
        AudioManeger.Instance.MusicVolume(musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManeger.Instance.SFXVolume(SfxSlider.value);
    }
}
