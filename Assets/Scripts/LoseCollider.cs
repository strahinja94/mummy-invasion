using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D()
    {
        MusicManager.Instance.StopSound("PlaySceneMusic");
        levelManager.LoadLevel("Lose");
    }
}
