using System.Collections.Generic;
using UnityEngine;

public class AudioSound : MonoBehaviour {

    public AudioSource audioSource;
    public float maxSoundVolume = 1.0f;
    public float soundVolumeMultiplier = 1.0f;

    public Dictionary<string, AudioClip> soundClips;
    public Dictionary<string, AudioSource> audioSourceDict;

    public void InitLoad()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds/");
        soundClips = new Dictionary<string, AudioClip>();
        audioSourceDict = new Dictionary<string, AudioSource>();

        for (int i = 0; i < clips.Length; i++)
        {
            soundClips.Add(clips[i].name, clips[i]);
        }
    }

    
    public void PlaySound(string audioSound)
    {
        AudioClip tempClip;
        if (soundClips.TryGetValue(audioSound, out tempClip))
        {
            audioSource.PlayOneShot(tempClip);
        }
    }

    public void PlaySoundLoop(string audioSound)
    {
        AudioSource tempSource;
        AudioSource outSource;
        AudioClip tempClip;
        if (soundClips.TryGetValue(audioSound, out tempClip))
        {
            tempSource = gameObject.AddComponent<AudioSource>();
            tempSource.clip = tempClip;
            if (!audioSourceDict.TryGetValue(audioSound, out outSource))
            {
                audioSourceDict.Add(audioSound, tempSource);
            }
            audioSourceDict[audioSound].loop = true;
            audioSourceDict[audioSound].Play();
        }
    }

    public void StopSoundLoop(string audioSound)
    {
        AudioSource tempSource;
        if (audioSourceDict.TryGetValue(audioSound, out tempSource))
        {
            tempSource.Stop();
        }
    }

    public void StopSound(string audioSound)
    {
        AudioClip tempClip;
        if (soundClips.TryGetValue(audioSound, out tempClip))
        {
            audioSource.clip = soundClips[audioSound];
            audioSource.Stop();
        }
        else
        {
            Debug.LogWarning("Sound clip didn't found");
        }
    }

    public void SetVolume()
    {
        audioSource.volume = soundVolumeMultiplier * maxSoundVolume;
        foreach (KeyValuePair<string, AudioSource> kvp in audioSourceDict)
        {
            kvp.Value.volume = soundVolumeMultiplier * maxSoundVolume;
        }
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
}
