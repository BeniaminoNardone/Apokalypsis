using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public int attackDamage = 1;
    public Transform attackPoint;
    public float attackRange = 0.2f;
    public LayerMask enemyLayer;
    public float attackCooldown = 1f; // Aggiungi un cooldown per l'attacco

    private float nextAttackTime = 0f; // Quando è possibile il prossimo attacco

    ParticleSystem blood;
    public void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("AttaccoMlee"))
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown; // Imposta il tempo per il prossimo attacco
            }
        }
    }

    public void Attack()
    {
        //play animation
        animator.SetTrigger("IsMleeAttack");

        //detect enemies
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position,attackRange,enemyLayer);

        //damage them
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("enemy colpito");

            enemy.GetComponent<fetopiccolo>().TakeDamage();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) {  return; }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
