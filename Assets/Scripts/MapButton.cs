using UnityEngine;

public class MapButton : MonoBehaviour {

    private LevelManager levelManager;
    public int levelNumber;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        gameObject.SetActive(levelNumber <= MetaData.levelsUnlocked);
    }

    public void LoadLevel()
    {
        MetaData.currentLevel = levelNumber;
        levelManager.LoadLevel("Game");
    }
}
