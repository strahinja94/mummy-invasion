using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    public float period;
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;
    public bool inPool = true;

    void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget || currentTarget.GetComponent<Defender>().inPool)
        {
            animator.SetBool("isAttacking", false);
        }
	}

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public float GetSpeed()
    {
        return currentSpeed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget && !currentTarget.GetComponent<Defender>().inPool)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
