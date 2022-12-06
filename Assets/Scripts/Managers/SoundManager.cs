using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private Player playerData;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    [SerializeField] private Slider musicSlider, sfxSlider;
    [SerializeField] private ButtonHandler musicMute, sfxMute;

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
        LoadSoundSettings();
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

    private void MuteMusic(bool state)
    {
        musicSource.mute = state;
    }
    private void MuteSFX(bool state)
    {
        sfxSource.mute = state;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = musicSlider.value;
        if (musicSource.volume <= 0)
        {
            musicMute.isActive = false;
            MuteMusic(true);
        }
        else
        {
            musicMute.isActive = true;
            MuteMusic(false);
        }
        musicMute.ButtonToggle();
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = sfxSlider.value;
        if (sfxSource.volume <= 0)
        {
            sfxMute.isActive = false;
            MuteSFX(true);
        }
        else
        {
            sfxMute.isActive = true;
            MuteSFX(false);
        }

        sfxMute.ButtonToggle();
    }

    public void SaveSoundSettings()
    {
        playerData.SaveSettings(musicSource.mute, sfxSource.mute, musicSource.volume, sfxSource.volume);
    }

    private void LoadSoundSettings()
    {
        musicSource.mute = playerData.musicMute;
        sfxSource.mute = playerData.sfxMute;
        musicSource.volume = playerData.musicVolume;
        sfxSource.volume = playerData.sfxVolume;

        musicSlider.value = musicSource.volume;
        sfxSlider.value = sfxSource.volume;
    }
}
