 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rbEnemy;
    Animator anim; 
    public GameObject enemyGraphics;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 5f;
    bool canflip = true;

    // Start is called before the first frame update
    void Awake()
    {
        rbEnemy = GetComponentInChildren<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player"){
            if(facingRight && collider.transform.position.x > transform.position.x){
                flip();
            rbEnemy.velocity = new Vector2(-speed, 0);
            }
            else if(!facingRight && collider.transform.position.x < transform.position.x){
                flip();
            rbEnemy.velocity = new Vector2(speed, 0);
            }
            else{
            canflip = false;
            anim.SetBool("run", true);
            }
            
        }
    }

    void OntriggerStay2d(Collider2D collider){
        if(collider.tag == "Player"){
            
            if(!facingRight)
                rbEnemy.AddForce(new Vector2(10,0) );
            else
                rbEnemy.AddForce(new Vector2(-10,0));
           
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "Player"){
            canflip = true;
            rbEnemy.velocity = new Vector2( 0, 0);
            anim.SetBool("run", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFlip){
            nextFlip = Time.time + facingTime;
            
        }
    }
    void flip()
    {
        if (!canflip) 
            return;
        facingRight = !facingRight;
        Vector3 vt = enemyGraphics.transform.localScale  ;
         vt.x *= -1;
         enemyGraphics.transform.localScale = vt; 
    } 
}
