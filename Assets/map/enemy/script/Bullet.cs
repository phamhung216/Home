using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

     private GameObject target;
    [SerializeField] private float speed;
    Rigidbody2D rb;
    [SerializeField] private GameObject Death;
    [SerializeField] private GameObject rock;
    private Collider2D col;
    [SerializeField] private LayerMask player;
    

    // Start is called before the first frame update
    
    void Start()
    {
           rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == ("Player")){
            Debug.Log("Pem");
            Instantiate(Death, gameObject.transform.position, Quaternion.identity);
            rock.SetActive(false);
        }

        if (col.gameObject.tag == ("Ground")){
            Debug.Log("Pem1");
            Instantiate(Death, gameObject.transform.position, Quaternion.identity);
            rock.SetActive(false);
        }

        if (col.gameObject.tag == ("Water")){
            Debug.Log("Pem2");
            Instantiate(Death, gameObject.transform.position, Quaternion.identity);
            rock.SetActive(false);
        }
    }


}


    // Update is called once per frame
    
