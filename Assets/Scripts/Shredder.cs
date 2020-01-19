using UnityEngine;

public class Shredder : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ObjectsPool.instance.AddObjectToPool(collider.gameObject);
    }
}
