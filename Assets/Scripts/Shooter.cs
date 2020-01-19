using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start()
    {
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerAheadInLane()
    {
        // exit if no attackers in lane
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                // attackers in front
                return true;
            }
        }

        // attackers behind 
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = ObjectsPool.instance.GetPooledObject(projectile.tag);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
        newProjectile.SetActive(true);
    }

    private void SetMyLaneSpawner()
    {
        Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find spawner in lane");
    }
}
