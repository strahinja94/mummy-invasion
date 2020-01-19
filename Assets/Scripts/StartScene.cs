using UnityEngine;

public class StartScene : MonoBehaviour {

	void Start ()
    {
        float volume = PlayerPrefsManager.GetMasterVolume();
        if (!MusicManager.Instance.IsPlaying())
        {
            MusicManager.Instance.PlaySound("StartSceneMusic");
        }
        MusicManager.Instance.SetSoundMultiplier(volume);
    }
}
