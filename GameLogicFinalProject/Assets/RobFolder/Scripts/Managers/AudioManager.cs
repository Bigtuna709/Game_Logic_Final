using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
    public Audio[] audioData;
    public AudioSource backGroundMusic;

    private void Start()
    {
        foreach(Audio audio in audioData)
        {
            audio.audioSource = gameObject.AddComponent<AudioSource>();
            audio.audioSource.clip = audio.audioClip;
            audio.audioSource.volume = audio.volume;
            audio.audioSource.pitch = audio.pitch;
            audio.audioSource.loop = audio.loop;
            audio.audioSource.playOnAwake = false;
        }
        backGroundMusic.Play();
    }

    public void PlayClip(string name)
    {
        Audio a = Array.Find(audioData, clip => clip.name == name);
        if(a == null)
        {
            Debug.Log("<color=red>No such audioclip with that name!</color>");
            return;
        }
        a.audioSource.Play();
    }

    public void StopCLip(string name)
    {
        Audio a = Array.Find(audioData, clip => clip.name == name);
        if (a == null)
        {
            Debug.Log("<color=red>No such audioclip with that name!</color>");
            return;
        }
        a.audioSource.Stop();
    }
}
