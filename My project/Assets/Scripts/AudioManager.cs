using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] music;
    public Sound[] sfx;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sfx, x => x.name == name);
        sfxSource.clip = s.audioClip;
        sfxSource.Stop();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, x => x.name == name);
        if(s==null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.audioClip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.audioClip);
        }
    }
}
