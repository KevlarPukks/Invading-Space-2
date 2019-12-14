using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SerializedMonoBehaviour
{
    public static SoundManager instance;
  [HideInInspector]  public AudioSource sfx;
    [SerializeField] public float Volume;
    [Title("Sounds")] public AudioClip GameOver;
    public AudioClip GetReady;
    public AudioClip Incoming;
    public AudioClip ShuttingDown;
    private void Awake()
    {
        if (instance == null) instance = this;
        sfx = GetComponent<AudioSource>();
    }

   public static void PlaySFX(AudioClip clip,float volume)
    {
        instance.sfx.PlayOneShot(clip, volume);
    }
    public static void PlaySFX(AudioClip clip)
    {
        instance.sfx.PlayOneShot(clip);
    }
}
