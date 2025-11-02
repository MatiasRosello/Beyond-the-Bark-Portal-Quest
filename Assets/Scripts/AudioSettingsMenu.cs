using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AudioSettingsMenu : MonoBehaviour
{
    [Header("Referencias")]
    public AssetReferenceT<AudioMixer> audioMixerReference;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Parámetros del Mixer")]
    public string musicParameter = "MusicVolume";
    public string sfxParameter = "SFXVolume";

    private AudioMixer audioMixer;

    private void Start()
    {
        audioMixerReference.LoadAssetAsync().Completed += OnMixerLoaded;
    }

    private void OnMixerLoaded(AsyncOperationHandle<AudioMixer> handle)
    {
        if (handle.Status != AsyncOperationStatus.Succeeded) { return; }

        audioMixer = handle.Result;

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
        if (audioMixer == null) { return; }

        value = Mathf.Clamp(value, 0.0001f, 1f);
        float dB = Mathf.Log10(value) * 40f;
        audioMixer.SetFloat(musicParameter, dB);
        PlayerPrefs.SetFloat(musicParameter, value);
    }

    public void SetSFXVolume(float value)
    {
        if (audioMixer == null) { return; }

        value = Mathf.Clamp(value, 0.0001f, 1f);
        float dB = Mathf.Log10(value) * 40f;
        audioMixer.SetFloat(sfxParameter, dB);
        PlayerPrefs.SetFloat(sfxParameter, value);
    }
}
