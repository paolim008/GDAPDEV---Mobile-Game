using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;

    public Sound[] sounds;

    public static AudioManager instance;

    

    public bool musicStatus, sfxStatus;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            switch (s.audioType)
            {
                case Sound.AudioTypes.SFX:
                    s.source.outputAudioMixerGroup = sfxMixerGroup;
                    break;
                case Sound.AudioTypes.MUSIC:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
        }
    }

    void Start()
    {
        Play("Theme");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();

    }

    //public void ToggleMusic(bool status)
    //{
    //    musicMixerGroup.audioMixer.SetFloat("MusicVolume", )
    //    musicSource.mute = status;
    //    musicStatus = status;
    //}
    //public void ToggleSfx(bool status)
    //{
    //    sfxSource.mute = status;
    //    sfxStatus = status;
    //}

    public void UpdateMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(AudioController.musicVolume)* 20);
        musicMixerGroup.audioMixer.SetFloat("SfxVolume", Mathf.Log10(AudioController.sfxVolume) * 20);

    }
}
