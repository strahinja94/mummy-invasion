using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public Text costText;
    public static GameObject selectedDefender;

    private Button[] buttons;

	void Start ()
    {
        buttons = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetComponent<Defender>().goldCost.ToString();
	}

    void OnMouseDown()
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
