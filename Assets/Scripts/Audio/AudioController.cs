using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public Slider _musicSlider, _sfxSlider;

    private void Awake()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicSave", 1f);
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxSave", 1f);
    }
    private void Update()
    {
        MusicVolume();
        SFXVolume();
        SaveVolume();
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicSave", _musicSlider.value);
        PlayerPrefs.SetFloat("sfxSave", _sfxSlider.value);
    }
    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(_sfxSlider.value);
    }
}
