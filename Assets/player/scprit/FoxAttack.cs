using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    public float AttackRate = 2f;
     float nextAttackTime = 0f;
    
    // Update is called once per frame
    
    void Update()
    {
        if (Time.time >= nextAttackTime)
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
            nextAttackTime = Time.time + 1f / AttackRate;
        }
        

    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("Attacked");
        }
        if (attackPoint == null)
        return;
        
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }
}
