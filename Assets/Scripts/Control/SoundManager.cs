using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public Sound[] backgroundSounds;
    public Sound[] soundEffects;

    private AudioSource backgroundAudioSource;
    private AudioSource sfxSource;

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

    }

    private void Start()
    {
        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundAudioSource.loop = true;
        backgroundAudioSource.playOnAwake = false;
        sfxSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayBackgroundSound(string name)
    {
        Sound s = System.Array.Find(backgroundSounds, sound => sound._name == name);
        backgroundAudioSource.clip = s.clip;
        backgroundAudioSource.volume = s.volume;
        backgroundAudioSource.Play();
    }
    public void StopBackgroundSound()
    {
        backgroundAudioSource.Stop();
    }
    public void PlaySoundEffect(string name)
    {
        Sound s = System.Array.Find(soundEffects, sound => sound._name == name);
        sfxSource.PlayOneShot(s.clip, s.volume);
    }
    public void SetBackgroundVolume(float volume)
    {
        backgroundAudioSource.volume = Mathf.Clamp01(volume);
        foreach (Sound sound in backgroundSounds)
        {
            sound.volume = volume;
        }
    }
    public void SetSfxtVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
        foreach (Sound sound in soundEffects)
        {
            sound.volume = volume;
        }
    }

}