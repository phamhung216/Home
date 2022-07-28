using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private float Left;
    [SerializeField] private float Right;
    [SerializeField] private float JumpLength;
    [SerializeField] private float JumpHeight;
    [SerializeField] private LayerMask Ground;
    private Collider2D col;
    private Rigidbody2D rb;
    private Animator anim;
    private bool FacingLeft = true;

    private Transform Player;
    private Vector2 Target;
    [SerializeField] private float AttackZoneX;
    [SerializeField] private float AttackZoneY;   
    [SerializeField] private Transform AttackZone1;

    private bool Attacking;
    


    private void Start(){
    
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Move(){
        anim.SetBool("Attacking", false);

        if (FacingLeft){

            if (transform.position.x > Left && col.IsTouchingLayers(Ground)){
                if (transform.localScale.x != 1){
                    transform.localScale = new Vector3(1,1);
                }
                
                
                    rb.velocity = new Vector2(-JumpLength, JumpHeight);
                    anim.SetBool("Jumping", true);
                
            }
        
        
            else{
                FacingLeft = false;
            }
        }
        
        else{

            if (transform.position.x < Right && col.IsTouchingLayers(Ground)){
                if (transform.localScale.x != -1){
                    transform.localScale = new Vector3(-1,1);
                }
                
                
                    rb.velocity = new Vector2(JumpLength, JumpHeight);
                    anim.SetBool("Jumping", true);
                
            }
        
        
            else{
                FacingLeft = true;
            }
        }
    }

    void Update(){
        
        if (anim.GetBool("Jumping")){
            if (rb.velocity.y <.1){
                 anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }
        if (col.IsTouchingLayers(Ground) && anim.GetBool("Falling")){
            anim.SetBool("Falling", false);
        }

        Attack();
        
    }

    

    void Attack(){
        float DistanceFromPlayer = Vector2.Distance(Player.position, transform.position);
        if ( DistanceFromPlayer <= AttackZoneX){
            anim.SetBool("Attacking", true);
            rb.velocity = new Vector2(-JumpLength, -JumpHeight);
            if (col.IsTouchingLayers(Ground)){
                rb.velocity = new Vector2(0,0);
                if (transform.position.x < Player.transform.position.x){
                    transform.localScale = new Vector3(-1,1);
                }
                else if (transform.position.x > Player.transform.position.x){
                    transform.localScale = new Vector3(1,1);
                }
            }

            

        }
        else if ( DistanceFromPlayer > AttackZoneX){
            anim.SetBool("Attacking", false);
            
        }

        

    }
    
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(AttackZone1.transform.position, new Vector3(AttackZoneX,AttackZoneY,0));
        
    }

}
