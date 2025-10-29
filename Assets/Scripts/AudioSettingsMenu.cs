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

        audioMixer.SetFloat(musicParameter, Mathf.Log10(Mathf.Max(value, 0.001f)) * 20f);
        PlayerPrefs.SetFloat(musicParameter, value);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat(sfxParameter, Mathf.Log10(Mathf.Max(value, 0.001f)) * 20f);
        PlayerPrefs.SetFloat(sfxParameter, value);
    }
}