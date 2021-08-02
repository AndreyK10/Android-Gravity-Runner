using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    public const string BUTTON_SOUND = "ButtonSound";
    public const string JUMP_SOUND = "JumpSound";
    public const string GAME_OVER_SOUND = "GameOverSound";
    public const string BGMUSIC = "BGMusic";

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.mute = sound.mute;
        }
    }
    private void Start()
    {
        PlaySound(BGMUSIC);
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }

    public void MuteMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.mute = !s.source.mute;
    }

    public void MuteSound(params string[] name)
    {
        for (int i = 0; i < name.Length; i++)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name[i]);
            if (s == null) return;
            s.source.mute = !s.source.mute;
        }
    }

}
