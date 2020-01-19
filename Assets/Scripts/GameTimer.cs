using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float baseLevelSeconds = 50;
    public float levelSeconds = 50;
    private Slider slider;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

	void Start ()
    {
        slider = GetComponent<Slider>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("YouWonLabel");
        winLabel.SetActive(false);
        levelSeconds = baseLevelSeconds + 10 * MetaData.currentLevel;
	}

	void Update ()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        if (!isEndOfLevel && Time.timeSinceLevelLoad >= levelSeconds)
        {
            winLabel.SetActive(true);
            MusicManager.Instance.PlaySound("quest_complete");
            if (MetaData.currentLevel == MetaData.maxLevel)
            {
                Invoke("GoToWinScene", 3.3f);
            }
            else
            {
                Invoke("GoToMap", 3.3f);
            }
            if (MetaData.currentLevel == MetaData.levelsUnlocked)
            {
                MetaData.levelsUnlocked++;
                PlayerPrefsManager.SetLevel(MetaData.levelsUnlocked);
            }
            isEndOfLevel = true;
        }
    }

    private void GoToMap()
    {
        MusicManager.Instance.StopSound("PlaySceneMusic");
        levelManager.LoadLevel("Map");
    }

    private void GoToWinScene()
    {
        MusicManager.Instance.StopSound("PlaySceneMusic");
        levelManager.LoadLevel("Win");
    }
}
