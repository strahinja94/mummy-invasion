using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand = true;
}

public class ObjectsPool : MonoBehaviour {

    public static ObjectsPool instance;
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;
    private DefenderSpawner defenderSpawner;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        defenderSpawner = GameObject.FindObjectOfType<DefenderSpawner>();
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = Instantiate(item.objectToPool) as GameObject;
                obj.transform.parent = gameObject.transform;
                obj.transform.position = gameObject.transform.position;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i=0; i<pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag.Contains(tag))
            {
                if (pooledObjects[i].tag.Contains("Defender"))
                {
                    pooledObjects[i].GetComponent<Defender>().inPool = false;
                }
                
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag.Contains(tag))
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool) as GameObject;
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    if (obj.tag.Contains("Defender"))
                    {
                        obj.GetComponent<Defender>().inPool = false;
                    }
                    return obj;
                }
            }
        }
        return null;
    }

    public void AddObjectToPool(GameObject obj)
    {
        if (obj.tag.Contains("Defender"))
        {
            obj.GetComponent<Defender>().inPool = true;
            defenderSpawner.matrix[(int)obj.transform.position.x - 1, (int)obj.transform.position.y - 1] = 0;
        }
        obj.gameObject.transform.parent = gameObject.transform;
        obj.gameObject.transform.position = gameObject.transform.position;
        obj.gameObject.SetActive(false);
        Health healthComponent = obj.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.health = healthComponent.maxHealth;
        }
    }
}


