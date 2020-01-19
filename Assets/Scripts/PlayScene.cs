using UnityEngine;

public class PlayScene : MonoBehaviour {

    void Start()
    {
        float volume = PlayerPrefsManager.GetMasterVolume();
        MusicManager.Instance.StopSound("StartSceneMusic");
        MusicManager.Instance.PlaySound("PlaySceneMusic");
        MusicManager.Instance.SetSoundMultiplier(volume);
    }
}
