using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float moveSpeed;
    [SerializeField] private bool MoveLeft;
    
    /*
    [SerializeField] private bool run;
    [SerializeField] private float runSpeed;
    [SerializeField] private float AttackZoneX;
    [SerializeField] private float AttackZoneY;   
    [SerializeField] private Transform AttackZone1;
    private Transform Player;
    */
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Attack();
    }
    void Move(){
        if (MoveLeft){
            rb.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(1,1);
        }
        else {
            rb.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(-1,1);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == ("Wall")){
            if (MoveLeft){
                MoveLeft = false;
            }
            else {
                MoveLeft = true;
            }
        }
    }

    /*
    void Attack(){
        float DistanceFromPlayer = Vector2.Distance(Player.position, transform.position);
        if ( DistanceFromPlayer < AttackZoneX ){
            anim.SetBool("Running", true);
            Debug.Log("In");
            if (transform.position.x > Player.transform.position.x){
                    rb.velocity = new Vector2(-runSpeed, 0);
                    transform.localScale = new Vector3(1,1);
                }
                else if (transform.position.x < Player.transform.position.x){
                    transform.localScale = new Vector3(-1,1);
                    rb.velocity = new Vector2(runSpeed, 0);
                }
        }
        else if (transform.position.x == Player.transform.position.x){
            rb.velocity = new Vector2 (0,0);
        }
        else{
            anim.SetBool("Running", false);
        }
        
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(AttackZone1.transform.position, new Vector3(AttackZoneX,AttackZoneY,0));
        
    }
    */

    void OnCollisionEnter2D(Collision2D col){
        if (col.collider.tag == "Player" && col.contacts[0].normal.y < 0){
            Debug.Log("Pong");
        }
    }
}