using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager{

    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BallFall,Resources.Load<AudioClip>("BallFall"));
        audioClips.Add(AudioClipName.HitBlock, Resources.Load<AudioClip>("HitBlock"));
        audioClips.Add(AudioClipName.HitPaddle, Resources.Load<AudioClip>("HitPaddle"));
    }

    public static void Play(AudioClipName audioClipName)
    {
        if(audioSource != null)
            audioSource.PlayOneShot(audioClips[audioClipName]);
    }

}
