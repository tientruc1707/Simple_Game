using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    // Tên của Exposed Parameters trong Audio Mixer
    private const string MUSIC_KEY = "MusicVolume";
    private const string SFX_KEY = "SFXVolume";

    // Key để lưu setting
    private const string MUSIC_SAVE_KEY = "MusicVolume";
    private const string SFX_SAVE_KEY = "SFXVolume";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_SAVE_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_SAVE_KEY, 1f);

        if (musicSlider != null)
            musicSlider.value = musicVolume;

        if (sfxSlider != null)
            sfxSlider.value = sfxVolume;

        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat(MUSIC_KEY, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MUSIC_SAVE_KEY, volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        if (mixer != null)
        {
            mixer.SetFloat(SFX_KEY, Mathf.Log10(volume) * 20);
        }
        PlayerPrefs.SetFloat(SFX_SAVE_KEY, volume);
        PlayerPrefs.Save();
    }

    // Play sound effect
    public void PlaySFX(AudioSource source, AudioClip clip)
    {
        if (source != null && clip != null)
        {
            source.clip = clip;
            source.Play();
        }
    }
}