using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioSound sound;

    private static MusicManager _instance;

    public static MusicManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicManager>();
                InitLoadAudio();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            AudioSound snd = gameObject.GetComponentInChildren<AudioSound>();
            _instance = this;
            _instance.sound = snd;
            InitLoadAudio();
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public static void InitLoadAudio()
    {
        _instance.sound.InitLoad();
    }

    public void PlaySound(string fxFilename)
    {
        sound.PlaySound(fxFilename);
    }

    public void StopSound(string fxFilename)
    {
        sound.StopSound(fxFilename);
    }

    public void PlaySoundLoop(string fxFilename)
    {
        sound.PlaySoundLoop(fxFilename);
    }

    public void StopSoundLoop(string fxFilename)
    {
        sound.StopSoundLoop(fxFilename);
    }

    public void MuteSound()
    {
        sound.soundVolumeMultiplier = 0;
        sound.SetVolume();
    }

    public void UnMuteSound()
    {
        sound.soundVolumeMultiplier = 1;
        sound.SetVolume();
    }

    public void SetSoundMultiplier(float multiplierValue)
    {
        if (multiplierValue < 0)
            multiplierValue = 0;

        if (multiplierValue > 1)
            multiplierValue = 1;

        sound.soundVolumeMultiplier = multiplierValue;
        sound.SetVolume();
    }

    public bool IsPlaying()
    {
        return sound.IsPlaying();
    }

}
