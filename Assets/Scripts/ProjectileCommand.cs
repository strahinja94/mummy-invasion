using UnityEngine;

public abstract class ProjectileCommand
{
    public enum Status { DONE, NOT_READY }
    public abstract Status Execute(Collider2D collider, float damage);
}

public class DealDamage : ProjectileCommand
{
    public override Status Execute(Collider2D collider, float damage)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        Health health = collider.gameObject.GetComponent<Health>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            return Status.DONE;
        }
        else
        {
            return Status.NOT_READY;
        }
    }
}

public class Freeze : ProjectileCommand
{
    public override Status Execute(Collider2D collider, float damage)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            if (attacker.GetSpeed() > 0)
            {
                attacker.SetSpeed(0.1f);
            }
            return Status.DONE;
        }
        else
        {
            return Status.NOT_READY;
        }
    }
}

