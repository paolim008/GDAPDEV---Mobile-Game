using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    [Header("SoundClips")] 
    [SerializeField] private AudioClip ButtonClick;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();

        //Keep object when switching scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy duplicate
        else if (instance != null & instance != this)
        {
            Destroy(gameObject);
        }
            

    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }

    public void ButtonClicked()
    {
        source.PlayOneShot(ButtonClick);
    }
}
