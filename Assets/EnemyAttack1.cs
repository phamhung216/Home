using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : MonoBehaviour
{
    private Transform Player;
    public float Speed;
    public float WarZone;
    public float DashZone;
    
    public float DashSpeed;

    public float StartWaitTime;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = StartWaitTime;

        
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceFromPlayer = Vector2.Distance(Player.position, transform.position);
        if(DistanceFromPlayer < WarZone && DistanceFromPlayer > DashZone){
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed* Time.deltaTime);
        }
        else if(DistanceFromPlayer <= DashZone)
        {   
            waitTime -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, DashSpeed* Time.deltaTime);
        }
        
        
       
    }
    
    


    
    void FixedUpdate(){
        
    }
    

    private void OnDrawGizmosSelected(){
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, WarZone); 
            Gizmos.DrawWireSphere(transform.position, DashZone); 
    }

    

}
