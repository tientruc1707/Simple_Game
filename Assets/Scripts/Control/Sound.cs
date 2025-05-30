using UnityEngine;

public class Sound : MonoBehaviour
{
    public string _name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;

};
