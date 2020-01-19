using UnityEngine;

public class Defender : MonoBehaviour {

    private GoldDisplay goldDisplay;
    public int goldCost = 100;
    public bool inPool = true;

    void Start()
    {
        goldDisplay = GameObject.FindObjectOfType<GoldDisplay>();
    }

    public void AddGold(int amount)
    {
        goldDisplay.AddGold(amount);
    }

}
