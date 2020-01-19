using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHealth = 100f;
    public float health = 100f;
	
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ObjectsPool.instance.AddObjectToPool(gameObject);
        }
    }
}
