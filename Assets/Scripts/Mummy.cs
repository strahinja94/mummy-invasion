using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Mummy : MonoBehaviour {

    private Animator animator;
    private Attacker attacker;

    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        animator.SetBool("isAttacking", true);
        attacker.Attack(obj);
    }
}
