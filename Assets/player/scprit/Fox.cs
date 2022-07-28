using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fox : MonoBehaviour
{ 
    Rigidbody2D rb;
    Animator anim;
    float dirX;
    public float moveSpeed = 3f;
    bool hurting, isDead;
    bool facingRight = true;

    public GameObject Player;
    public float maxHealth = 7;
    public float currentHealth;
    public Slider slider;
    
    Vector3 localScale;
    public GameObject DeadMenu;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        localScale = transform.localScale;
    
        currentHealth = maxHealth; //healthBar
        slider.value = maxHealth; //healthBar
        
        
    }

    // Update is called once per frame
    void Update() 
    {
        

        if (Input.GetButtonDown ("Jump") && !isDead && rb.velocity.y == 0) //jump
        rb.AddForce (Vector2.up * 400f);

        

        SetAnimationState();

        if (!isDead)
            dirX = Input.GetAxisRaw ("Horizontal") * moveSpeed ;
            
    }

    void FixedUpdate() //move
    {
     
        if (!hurting)
            rb.velocity = new Vector2 (dirX, rb.velocity.y);
            anim.SetBool ("walking", true);
        
                 
    }

    void LateUpdate()
    {
        checkWhereToFace();
    }

    void SetAnimationState() // set animation
    {
        if (dirX ==0){
            anim.SetBool ("walking", false);
                
            
        }
        if (rb.velocity.y == 0){
            anim.SetBool ("jumping", false);
            anim.SetBool ("falling", false);
                
        }
        if (Mathf.Abs(dirX) == 3 && rb.velocity.y == 0)
        anim.SetBool ("walking", true);
        

        if (rb.velocity.y > 0)
        anim.SetBool ("jumping", true);
             

        if (rb.velocity.y < 0){
            anim.SetBool ("jumping",false);
            anim.SetBool ("falling", true);
                
        }
    }

    void checkWhereToFace() //face where
    {
        if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;
    }

    void OnTriggerEnter2D (Collider2D col) 
    {
        if (col.gameObject.tag == ("Enemy")){ //healthbar
            currentHealth -= 1;
            slider.value -= 1;
        }
        

        if (col.gameObject.tag == ("Enemy") && currentHealth > 0) {
            anim.SetTrigger ("hurting");
            StartCoroutine ("Hurt");
        } 
        else if(currentHealth == 0) {
            dirX = 0;
            isDead = true;
            anim.SetTrigger ("isDead");
            this.enabled = false;
            rb.velocity = new Vector2(0, 0);
            Time.timeScale = 0f;
            DeadMenu.SetActive (true);
            
        }
        
        if (col.gameObject.tag == ("Water")){
            dirX = 0;
            isDead = true;
            currentHealth -= 10;
            slider.value -= 10;
            anim.SetTrigger ("isDead");
            Time.timeScale = 0f;
            DeadMenu.SetActive (true);
            rb.velocity = new Vector2(0, 0);
        }
    }
    
   

    IEnumerator Hurt()
    {
        hurting = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce (new Vector2(-200f, 200f));
        else
            rb.AddForce (new Vector2(200f, 200));
        yield return new WaitForSeconds (0.2f);
             hurting = false;
    }
}
