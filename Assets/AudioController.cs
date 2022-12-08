using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Player playerData;
    public static float musicVolume { get; private set; }
    public static float sfxVolume { get; private set; }

    [SerializeField] private Slider[] audioSliders;

    public void OnMusicVolumeChange(float value)
    {
        musicVolume = value;
        AudioManager.instance.UpdateMixerVolume();
    }
    public void OnSfxVolumeChange(float value)
    {
        sfxVolume = value;
        AudioManager.instance.UpdateMixerVolume();
    }

    public void SetToDefault(int value)
    {
        switch (value)
        {
            case 0: audioSliders[0].value = .5f;
                break;
            case 1: audioSliders[1].value = .5f;
                break;
        }
    }

    public void PlayTone()
    {
        AudioManager.instance.Play("Button_Click");
    }

}
