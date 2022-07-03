using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance = null;
    public AudioClip techno_bg_music;
    public AudioClip GoalBloop;
    public AudioClip HitPaddleBloop;
    public AudioClip LossBuzz;
    public AudioClip WallBloop;
    public AudioClip WinSound;
    private AudioSource SoundEffect;

    void Start() {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        AudioSource[] sources = GetComponents<AudioSource>();
        foreach(AudioSource source in sources)
        {
            if(source.clip == null)
            {
                SoundEffect = source;
            }
        }
    }

    public void playOneShot(AudioClip clip)
    {
        SoundEffect.PlayOneShot(clip);
    }
}
