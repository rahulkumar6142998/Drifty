
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManger : MonoBehaviour
{
    public Sound[] sound;
    public static AudioManger instance;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach(Sound s in sound) // Help to find or call the sound form the array of datatype sound
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }
    private void Start()
    {
        Play("Theme");
    }
    public void Play(string name)
    {
       Sound s = Array.Find(sound, sound => sound.name == name);

        if(s==null)
        {
            return;
        }
        else
        {
            s.source.Play();
        }
    }
    
}
