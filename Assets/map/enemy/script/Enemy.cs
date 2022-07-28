using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Animator animator;
    public int maxHealth = 2;
    public int currentHealth;
    public GameObject gob;
    public GameObject Death;
    

    void Start()
    {
        currentHealth = maxHealth;
    
    }
   
    
    
 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <=0)
        {
            Die();
            
            
        }   

    }
    public void Die()
    {
        Debug.Log ("Die!");
        GetComponent<Collider2D >().enabled = false;
        this.enabled = false;
        Instantiate(Death, gameObject.transform.position, Quaternion.identity);
        gob.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.collider.tag == "Player" && col.contacts[0].normal.y < 0){
            Debug.Log("Pong");
            Die();
            
        }
    }

}
