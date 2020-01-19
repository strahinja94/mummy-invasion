using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;
    public enum ProjectileCommandEnum {DEAL_DAMAGE, FREEZE}
    public List<ProjectileCommandEnum> projectileCommands;
    private Dictionary<ProjectileCommandEnum, ProjectileCommand> dict;

    void Start () {
        dict = new Dictionary<ProjectileCommandEnum, ProjectileCommand>()
        {
            { ProjectileCommandEnum.DEAL_DAMAGE, new DealDamage()},
            { ProjectileCommandEnum.FREEZE, new Freeze() }
        };
    }

    void Update ()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        List<ProjectileCommand.Status> statuses = new List<ProjectileCommand.Status>();
        foreach (ProjectileCommandEnum projectileCommand in projectileCommands)
        {
            ProjectileCommand.Status status = dict[projectileCommand].Execute(collider, damage);
            statuses.Add(status);
        }
        if (!statuses.Contains(ProjectileCommand.Status.NOT_READY))
        {
            ObjectsPool.instance.AddObjectToPool(gameObject);
        }
    }
}
