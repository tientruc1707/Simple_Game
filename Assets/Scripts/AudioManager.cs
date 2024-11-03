using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
    public void SoundVolumeChanged(Slider SoundSlider)
    {
        SoundManager.SoundVolume = SoundSlider.value;
    }

    public void MusicVolumeChanged(Slider MusicSlider)
    {
        SoundManager.MusicVolume = MusicSlider.value;
    }
}
