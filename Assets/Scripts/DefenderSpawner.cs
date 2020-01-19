using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject parent;
    private GoldDisplay goldDisplay;
    public int[,] matrix;

    void Start()
    {
        matrix = new int[9, 5];
        goldDisplay = GameObject.FindObjectOfType<GoldDisplay>();
        parent = GameObject.Find("Defenders");
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;
        if (!Button.selectedDefender)
        {
            Debug.Log("Please select defender to spawn");
            return;
        }
        int defenderCost = defender.GetComponent<Defender>().goldCost;
        if (matrix[(int)roundedPos.x - 1, (int)roundedPos.y - 1] == 0 && goldDisplay.UseGold(defenderCost) == GoldDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient gold or occupied field");
        }
    }

    void SpawnDefender(Vector2 position, GameObject defender)
    {
        GameObject newDefender = ObjectsPool.instance.GetPooledObject(defender.tag);
        newDefender.transform.position = position;
        newDefender.SetActive(true);
        newDefender.transform.parent = parent.transform;
        matrix[(int)position.x - 1, (int)position.y - 1] = 1;
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 triplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(triplet);
        return worldPos;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
