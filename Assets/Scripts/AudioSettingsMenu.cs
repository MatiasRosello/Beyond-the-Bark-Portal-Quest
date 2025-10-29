using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
    [Header("Referencias")]
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Parámetros del Mixer")]
    public string musicParameter = "MusicVolume";
    public string sfxParameter = "SFXVolume";

    private void Start()
    {
        
        float musicValue = PlayerPrefs.GetFloat(musicParameter, 0.75f);
        float sfxValue = PlayerPrefs.GetFloat(sfxParameter, 0.75f);

        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;

        SetMusicVolume(musicValue);
        SetSFXVolume(sfxValue);

       
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        float dB = Mathf.Log10(value) * 40f; 
        audioMixer.SetFloat(musicParameter, dB);
        PlayerPrefs.SetFloat(musicParameter, value);
    }

    public void SetSFXVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        float dB = Mathf.Log10(value) * 40f;
        audioMixer.SetFloat(sfxParameter, dB);
        PlayerPrefs.SetFloat(sfxParameter, value);
    }
}