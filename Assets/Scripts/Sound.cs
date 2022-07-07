using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance = null;
    public AudioClip goalBloop;
    public AudioClip hitPaddleBloop;
    public AudioClip lossBuzz;
    public AudioClip wallBloop;
    public AudioClip winSound;
    private AudioSource soundEffect;

    void Start() {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        AudioSource[] sources = GetComponents<AudioSource>();
        foreach(AudioSource source in sources)
        {
            if(source.clip == null)
            {
                soundEffect = source;
            }
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffect.PlayOneShot(clip);
    }
}
