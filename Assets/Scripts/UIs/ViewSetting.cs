using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewSetting : View
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Slider _soundVolume;
    [SerializeField] private Slider _musicVolume;
    public override void Initialize()
    {
        _backButton.onClick.AddListener(() => ViewManager.ShowLast());
        AudioManager.Instance.SoundVolumeChanged(_soundVolume);
        AudioManager.Instance.MusicVolumeChanged(_musicVolume);
    }
}
