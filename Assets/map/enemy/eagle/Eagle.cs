using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{

    

    /*
    public float Left;
    public float Right;
    bool FacingRight = true;
    
    */
    
    Rigidbody2D rb;
    Vector3 localScale;
    [SerializeField] private float MoveSpeed = 1f;

    private Animator anim;
    private Transform player;
    [SerializeField] private float Speed;
    [SerializeField] private float WarZone;
    [SerializeField] private float ShootingZone;
    
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform BulletParent;
    [SerializeField] private float fireRate = 1;
    private float nextFireTime;
    [SerializeField] private Transform StartPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        
        rb = GetComponentInChildren<Rigidbody2D>();
        localScale = transform.localScale;
        

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        

    }

    // Update is called once per frame
    /* void Move(){
        if (FacingRight){

            if (transform.position.x > Left){
                if (transform.localScale.x != 1){
                    transform.localScale = new Vector3(1,1);
                    rb.velocity = new Vector2(-MoveSpeed, 0);
                }
            }
            else{
                FacingRight = false;
            }
        }
        
        else{

            if (transform.position.x < Right){
                if (transform.localScale.x != -1){
                    transform.localScale = new Vector3(-1,1);
                    rb.velocity = new Vector2(MoveSpeed, 0);
                }
                
                
            }
        
        
            else{
                FacingRight = true;
            }
        }
    } */

    void Update()
    {
        //Move();

        float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(DistanceFromPlayer < WarZone && DistanceFromPlayer > ShootingZone){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed* Time.deltaTime);
            
            if (transform.position.x < player.transform.position.x){
                transform.localScale = new Vector3(-1,1);
            }
            else {
                transform.localScale = new Vector3(1,1);
            }
        }
        else if(DistanceFromPlayer <= ShootingZone && nextFireTime <= Time.time)
        {   
            anim.SetBool("Attack", true);

            if (transform.position.x < player.transform.position.x){
                transform.localScale = new Vector3(-1,1);
            }
            else {
                transform.localScale = new Vector3(1,1);
            }

        }
        else if(DistanceFromPlayer > WarZone && DistanceFromPlayer > ShootingZone){
            anim.SetBool("Attack",false);
            transform.position = Vector2.MoveTowards(transform.position, StartPosition.transform.position, MoveSpeed*Time.deltaTime);
        
            if (transform.position.x < player.transform.position.x){
                transform.localScale = new Vector3(1,1);
            }
            else {
                transform.localScale = new Vector3(-1,1);
            }
        
        }

        
    }

    public void Attack(){
        Instantiate(Bullet,BulletParent.transform.position, Quaternion.identity) ;
            nextFireTime = Time.time + fireRate;
    }
   
    
    
    private void OnDrawGizmosSelected(){
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, WarZone); 
            Gizmos.DrawWireSphere(transform.position, ShootingZone); 
             
    }
}
