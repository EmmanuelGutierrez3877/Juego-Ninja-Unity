using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    public AudioSource source;
    public bool loop;
}

public class AudioAdmin : MonoBehaviour {
    public Sound[] sounds;
    public static AudioAdmin instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
            s.source.loop = s.loop;
        }
    }

    public void PlayAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sonido: " + name + " no encontrado");
        }
        s.source.Play();
    }

    public void StopAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sonido: " + name + " no encontrado");
        }
        s.source.Stop();
    }

    // Use this for initialization
    void Start () {
        PlayAudio("fondo");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
