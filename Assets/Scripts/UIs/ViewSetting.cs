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
    }

    void Start()
    {
        _soundVolume.value = 100;
        _musicVolume.value = 100;
    }
    public void Update()
    {
        AudioManager.Instance.SoundVolumeChanged(_soundVolume);
        AudioManager.Instance.MusicVolumeChanged(_musicVolume);
    }
}
