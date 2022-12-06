using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    [SerializeField] private Slider musicSlider, sfxSlider;

    private void Awake()
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

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }


    }
    public void PauseMusic()
    {
        musicSource.Pause();
    }
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }    
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = musicSlider.value;
    }    
    public void SFXVolume(float volume)
    {
        sfxSource.volume = sfxSlider.value;
    }


}
