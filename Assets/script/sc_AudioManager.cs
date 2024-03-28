using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_AudioManager : MonoBehaviour
{
    public AudioSource _audio_source;
    public AudioClip music;

    public static sc_AudioManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        _audio_source.clip = music;
        _audio_source.Play();
    }
}
