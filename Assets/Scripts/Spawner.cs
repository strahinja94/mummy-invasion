using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabs;
    public float initialDelayTime = 5f;
    public float timer = 0f;

    void Update ()
    {
        timer += Time.deltaTime;

        if (timer > initialDelayTime)
        {
            foreach (GameObject attacker in attackerPrefabs)
            {
                if (IsTimeToSpawn(attacker))
                {
                    Spawn(attacker);
                }
            }
        }
	}

    private bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float period = attacker.period;
        float frequency = 1 / (period - MetaData.difficulty * MetaData.currentLevel / 2);
        float threshold = frequency * Time.deltaTime / 5;
        return Random.value < threshold;
    }

    void Spawn(GameObject myGameObject)
    {   
        GameObject attackerObject = ObjectsPool.instance.GetPooledObject(myGameObject.tag);
        attackerObject.transform.parent = transform;
        attackerObject.transform.position = transform.position;
        attackerObject.SetActive(true);
    }
}
