using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewSetting : View
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider sfxSlider;
    public override void Initialize()
    {
        _backButton.onClick.AddListener(() => ViewManager.ShowLast());
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        SetMusicVolume(_soundSlider.value);
        SetSFXVolume(sfxSlider.value);
    }
    public void SetMusicVolume(float volume)
    {
        SoundManager.Instance.SetBackgroundVolume(volume);
    }
    public void SetSFXVolume(float volume)
    {
        SoundManager.Instance.SetSfxtVolume(volume);
    }
}
