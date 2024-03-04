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
   
    
    ParticleSystem blood;
    public void Update()
    {
        // Controlla se è stato premuto il pulsante X del DualSense 5
        if (Input.GetButtonDown("AttaccoMlee"))
        {
            // Chiama la funzione del tuo personaggio
            Attack();
        }
    }

    public void Attack(){
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


