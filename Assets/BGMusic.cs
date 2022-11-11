using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    private static BGMusic BGMusicInstance;
    private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (BGMusicInstance == null)
        {
            BGMusicInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
        _audioSource = GetComponent<AudioSource>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<BGMusic>().PlayMusic();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
