using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static SFXManager sfxManagerInstance;
    private AudioSource buttonAudio;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (sfxManagerInstance == null)
        {
            sfxManagerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
        buttonAudio = GetComponent<AudioSource>();
    }
    public void PressButton()
    {
        buttonAudio.Play();
    }
}
